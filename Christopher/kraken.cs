using System;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KrakenCSharpExampleConsole
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            //TODO: UPDATE WITH YOUR KEYS :)
            string apiPublicKey = "YOUR_PUBLIC_KEY";
            string apiPrivateKey = "YOUR_PRIVATE_KEY";

            try
            {
                System.Console.WriteLine("|=========================================|");
                System.Console.WriteLine("|        KRAKEN.COM C# TEST APP           |");
                System.Console.WriteLine("|=========================================|");
                System.Console.WriteLine();

                #region Public REST API Examples

                if (1 == 0)
                {
                    string publicResponse = "";

                    string publicEndpoint = "SystemStatus";
                    string publicInputParameters = "";

                    //MORE PUBLIC REST EXAMPLES
                    //*

                    //string publicEndpoint = "AssetPairs";
                    //string publicInputParameters = "pair=ethusd,xbtusd";

                    //string publicEndpoint = "Ticker";
                    //string publicInputParameters = "pair=ethusd";

                    //string publicEndpoint = "Trades";
                    //string publicInputParameters = "pair=ethusd&since=0";

                    //*

                    publicResponse = await QueryPublicEndpoint(publicEndpoint, publicInputParameters);
                    System.Console.WriteLine(publicResponse);
                }

                #endregion Public REST API Examples

                #region Private REST API Examples

                if (1 == 0)
                {
                    string privateResponse = "";

                    string privateEndpoint = "Balance";
                    string privateInputParameters = "";

                    //MORE PRIVATE REST EXAMPLES
                    //*

                    //string privateEndpoint = "AddOrder";
                    //string privateInputParameters = "pair=xbteur&type=buy&ordertype=limit&price=1.00&volume=1";

                    //string privateEndpoint = "AddOrder"
                    //string privateInputParameters = "pair=xdgeur&type=sell&ordertype=limit&volume=3000&price=%2b10.0%" //Positive Percentage Example (%2 represtes +, which is a reseved character in HTTP)

                    //string privateEndpoint = "AddOrder"
                    //string privateInputParameters = "pair=xdgeur&type=sell&ordertype=limit&volume=3000&price=-10.0%" //Negative Percentage Example

                    //string privateEndpoint = "AddOrder"
                    //string privateInputParameters = "pair=xdgeur&type=buy&ordertype=market&volume=3000&userref=789" //Userref Example

                    //string privateEndpoint = "Balance" //{"error":[]} IS SUCCESS, Means EMPTY BALANCE
                    //string privateInputParameters = ""

                    //string privateEndpoint = "QueryOrders"
                    //string privateInputParameters = "txid=OFUSL6-GXIIT-KZ2JDJ"

                    //string privateEndpoint = "AddOrder"
                    //string privateInputParameters = "pair=xdgusd&type=buy&ordertype=market&volume=5000"

                    //string privateEndpoint = "DepositAddresses"
                    //string privateInputParameters = "asset=xbt&method=Bitcoin"

                    //string privateEndpoint = "DepositMethods"
                    //string privateInputParameters = "asset=eth"

                    //string privateEndpoint = "WalletTransfer"
                    //string privateInputParameters = "asset=xbt&to=Futures Wallet&from=Spot Wallet&amount=0.0045"

                    //string privateEndpoint = "TradesHistory"
                    //string privateInputParameters = "start=1577836800&end=1609459200"

                    //string privateEndpoint = "GetWebSocketsToken"
                    //string privateInputParameters = ""

                    //*

                    privateResponse = await QueryPrivateEndpoint(privateEndpoint,
                                                                 privateInputParameters,
                                                                 apiPublicKey,
                                                                 apiPrivateKey);
                    System.Console.WriteLine(privateResponse);
                }

                #endregion Private REST API Examples

                #region Public WebSocket API Examples

                //if (1 == 0)
                //{
                //    string publicWebSocketURL = "wss://ws.kraken.com/";
                //    string pulbicWebSocketSubscriptionMsg = "{ \"event\": \"subscribe\", \"subscription\": { \"name\": \"ticker\"}, \"pair\": [ \"XBT/EUR\",\"ETH/USD\" ]}";

                //    //MORE PRUBLIC WEBSOCKET EXAMPLES
                //    //*

                //    //string pulbicWebSocketSubscriptionMsg = "{ \"event\": \"subscribe\", \"subscription\": { \"interval\": 1440, \"name\": \"ohlc\"}, \"pair\": [ \"XBT/EUR\"]}";

                //    //string pulbicWebSocketSubscriptionMsg = "{ \"event\": \"subscribe\", \"subscription\": { \"name\": \"spread\"}, \"pair\": [ \"XBT/EUR\",\"ETH/USD\" ]}";

                //    //*

                //    await OpenAndStreamWebSocketSubscription(publicWebSocketURL, pulbicWebSocketSubscriptionMsg);

                //}

                #endregion Public WebSocket API Examples

                #region Private WebSocket API Examples

                //if (1 == 0)
                //{
                //    string privateWebSocketURL = "wss://ws-auth.kraken.com/";

                //    //GET AND EXTRACT THE WEBSOCKET TOKEN FORM THE JSON RESPONSE
                //    string webSocketRestResponseJSON = await QueryPrivateEndpoint("GetWebSocketsToken", "", apiPublicKey, apiPrivateKey);

                //    var splits = webSocketRestResponseJSON.Split(new string[] { "\"token\":\"", "\"}}" }, StringSplitOptions.None);
                //    string webSocketToken = splits[1];

                //    string privateWebSocketSubscriptionMsg = "{ \"event\": \"subscribe\", \"subscription\": { \"name\": \"ownTrades\", \"token\": \"#TOKEN#\"}}";

                //    //MORE PRIVATE WEBSOCKET EXAMPLES
                //    //*

                //    //#TOKEN# IS A PLACEHOLDER

                //    //string privateWebSocketSubscriptionMsg = "{ \"event\": \"subscribe\", \"subscription\": { \"name\": \"openOrders\", \"token\": \"#TOKEN#\"}}";

                //    //string privateWebSocketSubscriptionMsg = "{ \"event\": \"subscribe\", \"subscription\": { \"name\": \"balances\", \"token\": \"#TOKEN#\"}}";

                //    //string addOrderExample =  "{\"event\":\"addOrder\",\"reqid\":1234,\"ordertype\":\"limit\",\"pair\":\"XBT/EUR\",\"token\":\"#TOKEN#\",\"type\":\"buy\",\"volume\":\"1\", \"price\":\"1.00\"}";

                //    //*

                //    //REPLACE PLACEHOLDER WITH TOKEN
                //    privateWebSocketSubscriptionMsg = privateWebSocketSubscriptionMsg.Replace("#TOKEN#", webSocketToken);
                //    await OpenAndStreamWebSocketSubscription(privateWebSocketURL, privateWebSocketSubscriptionMsg);

                //}

                #endregion Private WebSocket API Examples

                System.Console.WriteLine();
                System.Console.WriteLine("|=========================================|");
                System.Console.WriteLine("|   END OF PROGRAM, HAVE A NICE DAY :)    |");
                System.Console.WriteLine("|=========================================|");
                System.Console.WriteLine();
            }
            catch (Exception e)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("AN EXCEPTION OCCURED :(");
                System.Console.WriteLine(e.ToString());
            }
        }

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

        #region WebSocket API

        //private static async Task OpenAndStreamWebSocketSubscription(string connectionURL, string webSocketSubscription)
        //{
        //    try
        //    {
        //        ClientWebSocket webSocketClient = new ClientWebSocket();
        //        CancellationTokenSource stoppingToken = new CancellationTokenSource();

        //        //OPEN CONNECTION
        //        await webSocketClient.ConnectAsync(new Uri(connectionURL), CancellationToken.None);
        //        System.Console.WriteLine("WEBSOCKET CONNECTION OPEN!");

        //        //SEND SUBSCRIPTION MESSAGE
        //        System.Console.WriteLine("WEBSOCKET SUBSCRIPTION MESSAGE:");
        //        System.Console.WriteLine(webSocketSubscription);
        //        if (webSocketClient.State == WebSocketState.Open)
        //        {
        //            await webSocketClient.SendAsync(Encoding.UTF8.GetBytes(webSocketSubscription),
        //                                            WebSocketMessageType.Text,
        //                                            true,
        //                                            stoppingToken.Token);
        //        }

        //        //RECEIVE AND PRINT MESSAGE
        //        do
        //        {
        //            await ReceiveMessage(webSocketClient, stoppingToken.Token);
        //        } while (webSocketClient.State == WebSocketState.Open);

        //        //CLOSE CONNECTION
        //        await webSocketClient.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "", stoppingToken.Token);
        //    }
        //    catch (OperationCanceledException)
        //    {
        //        //DO NOTHING - ASSUME WAS REQUESTED
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private static async Task ReceiveMessage(ClientWebSocket socket, CancellationToken stoppingToken)
        //{
        //    var buffer = new ArraySegment<byte>(new byte[2048]);
        //    while (!stoppingToken.IsCancellationRequested)
        //    {
        //        WebSocketReceiveResult result;
        //        using (var ms = new MemoryStream())
        //        {
        //            do
        //            {
        //                result = await socket.ReceiveAsync(buffer, stoppingToken);
        //                ms.Write(buffer.Array, buffer.Offset, result.Count);
        //            } while (!result.EndOfMessage);

        //            if (result.MessageType == WebSocketMessageType.Close)
        //            {
        //                break;
        //            }

        //            string wsMsg = "";
        //            ms.Seek(0, SeekOrigin.Begin);
        //            using (var reader = new StreamReader(ms, Encoding.UTF8))
        //            {
        //                wsMsg = await reader.ReadToEndAsync();
        //            }
        //            string msgTime = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss") + ": ";
        //            System.Console.WriteLine(msgTime + wsMsg);
        //        }
        //    };
        //}

        #endregion WebSocket API
    }
}