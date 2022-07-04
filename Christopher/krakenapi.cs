﻿using System;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Christopher
{
    public class krakenapi
    {
        //TODO: UPDATE WITH YOUR KEYS :)
        private string apiPublicKey = "YOUR_PUBLIC_KEY";

        private string apiPrivateKey = "YOUR_PRIVATE_KEY";

        #region Public REST API Endpoints

        private static async Task<string> QueryPublicEndpoint(string endpointName, string inputParameters)
        {
            string jsonData;
            string baseDomain = "https://api.kraken.com";
            string publicPath = "/0/public/";
            string apiEndpointFullURL = baseDomain + publicPath + endpointName + "?" + inputParameters;
            using (HttpClient client = new HttpClient())
            {
                jsonData = await client.GetStringAsync(apiEndpointFullURL);
            }
            return jsonData;
        }

        #endregion Public REST API Endpoints

        #region Private REST API Endpoints

        private static async Task<string> QueryPrivateEndpoint(string endpointName,
                                                               string inputParameters,
                                                               string apiPublicKey,
                                                               string apiPrivateKey)
        {
            string baseDomain = "https://api.kraken.com";
            string privatePath = "/0/private/";

            string apiEndpointFullURL = baseDomain + privatePath + endpointName;
            string nonce = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            if (string.IsNullOrWhiteSpace(inputParameters) == false)
            {
                inputParameters = "&" + inputParameters;
            }
            string apiPostBodyData = "nonce=" + nonce + inputParameters;
            string signature = CreateAuthenticationSignature(apiPrivateKey,
                                                             privatePath,
                                                             endpointName,
                                                             nonce,
                                                             inputParameters);
            string jsonData;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("API-Key", apiPublicKey);
                client.DefaultRequestHeaders.Add("API-Sign", signature);
                client.DefaultRequestHeaders.Add("User-Agent", "KrakenDotNet Client");
                StringContent data = new StringContent(apiPostBodyData, Encoding.UTF8, "application/x-www-form-urlencoded");
                HttpResponseMessage response = await client.PostAsync(apiEndpointFullURL, data);
                jsonData = response.Content.ReadAsStringAsync().Result;
            }

            return jsonData;
        }

        #endregion Private REST API Endpoints

        #region Authentication Algorithm

        public static string CreateAuthenticationSignature(string apiPrivateKey,
                                                           string apiPath,
                                                           string endpointName,
                                                           string nonce,
                                                           string inputParams)
        {
            byte[] sha256Hash = ComputeSha256Hash(nonce, inputParams);
            byte[] sha512Hash = ComputeSha512Hash(apiPrivateKey, sha256Hash, apiPath, endpointName, nonce, inputParams);
            string signatureString = Convert.ToBase64String(sha512Hash);
            return signatureString;
        }

        private static byte[] ComputeSha256Hash(string nonce, string inputParams)
        {
            byte[] sha256Hash;
            string sha256HashData = nonce.ToString() + "nonce=" + nonce.ToString() + inputParams;
            using (var sha = SHA256.Create())
            {
                sha256Hash = sha.ComputeHash(Encoding.UTF8.GetBytes(sha256HashData));
            }
            return sha256Hash;
        }

        private static byte[] ComputeSha512Hash(string apiPrivateKey,
                                                byte[] sha256Hash,
                                                string apiPath,
                                                string endpointName,
                                                string nonce,
                                                string inputParams)
        {
            string apiEndpointPath = apiPath + endpointName;
            byte[] apiEndpointPathBytes = Encoding.UTF8.GetBytes(apiEndpointPath);
            byte[] sha512HashData = apiEndpointPathBytes.Concat(sha256Hash).ToArray();
            HMACSHA512 encryptor = new HMACSHA512(Convert.FromBase64String(apiPrivateKey));
            byte[] sha512Hash = encryptor.ComputeHash(sha512HashData);
            return sha512Hash;
        }

        #endregion Authentication Algorithm
    }
}