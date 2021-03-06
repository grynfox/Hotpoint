﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppUtility.Http
{
    public class HttpRequest
    {
        private HttpClient client;
        public static string serverUrl { get; private set; }
        public bool HasAuthorized { get; private set; }

        internal HttpRequest(string serverUrl)
        {
            client = new HttpClient();
            HttpRequest.serverUrl = serverUrl;
        }

        internal void InsertAuthorization(AuthenticationHeaderValue auth)
        {
            this.client.DefaultRequestHeaders.Authorization = auth;
        }

        /// <summary>
        /// Envia uma requisição post x-www/form-urlEncoded para o servidor
        /// </summary>
        /// <param name="model">Objeto a ser enviado</param>
        /// <returns></returns>
        public async Task<T> PostAsync<T>(IXW3FormModel model)
        {
            FormUrlEncodedContent form = new FormUrlEncodedContent(model.GetBody());
            HttpResponseMessage response = await client.PostAsync(serverUrl + model.GetControllerPath(), form).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var stringResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(stringResult);
        }
        /// <summary>
        /// Envia uma requisição post multpart/form-data para o servidor
        /// </summary>
        /// <param name="model">Objeto a ser enviado</param>
        /// <returns></returns>
        public async Task<T> PostAsync<T>(IDataFormModel model)
        {
            MultipartFormDataContent form = new MultipartFormDataContent();
            foreach (var value in model.GetBody())
            {
                form.Add(new StringContent(value.Value), String.Format("\"{0}\"", value.Key));
            }
            foreach (var file in model.GetBinaryBody())
            {
                HttpContent content = new StreamContent(file.Value.Source);
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "img_upload",
                    FileName = file.Value.Path.Split('\\', '/').Last(),
                };
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                form.Add(content);
            }
            //httpClient.Timeout = TimeSpan.FromMinutes(20);
            HttpResponseMessage response = await client.PostAsync(serverUrl + model.GetControllerPath(), form).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var stringResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(stringResult);
        }
        /// <summary>
        /// Envia uma requisição Put x-www/form-urlEncoded para o servidor
        /// </summary>
        /// <param name="model">Objeto a ser enviado</param>
        /// <returns></returns>
        public async Task<T> PutAsync<T>(IXW3FormModel model)
        {
            FormUrlEncodedContent form = new FormUrlEncodedContent(model.GetBody());
            HttpResponseMessage response = await client.PutAsync(serverUrl + model.GetControllerPath(), form).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var stringResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(stringResult);
        }

        /// <summary>
        /// Envia uma requisição put multpart/form-data para o servidor
        /// </summary>
        /// <param name="model">Objeto a ser enviado</param>
        /// <returns></returns>
        public async Task<T> PutAsync<T>(IDataFormModel model)
        {
            MultipartFormDataContent form = new MultipartFormDataContent();
            foreach (var value in model.GetBody())
            {
                form.Add(new StringContent(value.Value), String.Format("\"{0}\"", value.Key));
            }
            foreach (var file in model.GetBinaryBody())
            {
                HttpContent content = new StreamContent(file.Value.Source);
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "img_upload",
                    FileName = file.Value.Path.Split('\\', '/').Last(),
                };
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                form.Add(content);
            }
            //httpClient.Timeout = TimeSpan.FromMinutes(20);
            HttpResponseMessage response = await client.PutAsync(serverUrl + model.GetControllerPath(), form).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var stringResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(stringResult);
        }

        /// <summary>
        /// Envia uma requisição Delete para o servidor
        /// </summary>
        /// <param name="model">Objeto a ser enviado</param>
        /// <returns></returns>
        public async Task<T> DelAsync<T>(IXW3FormModel model)
        {
            string controlerPath = model.GetControllerPath();
            if ((controlerPath.Length - 1) != controlerPath.LastIndexOf('/'))
                controlerPath += '/';
            string constructor = serverUrl + controlerPath + "?";
            foreach (KeyValuePair<string, string> str in model.GetBody())
            {
                constructor += str.Key + "=" + str.Value + "&";
            }
            constructor = constructor.Remove(constructor.Length - 1);
            HttpResponseMessage response = await client.DeleteAsync(new Uri(constructor)).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var stringResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(stringResult);
        }

        /// <summary>
        /// Envia uma requisição Get para o servidor
        /// </summary>
        /// <param name="model">Objeto a ser enviado</param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(IXW3FormModel model)
        {
            string controlerPath = model.GetControllerPath();
            if ((controlerPath.Length - 1) != controlerPath.LastIndexOf('/'))
                controlerPath += '/';
            string constructor = serverUrl + controlerPath + "?";
            foreach (KeyValuePair<string, string> str in model.GetBody())
            {
                constructor += str.Key + "=" + str.Value + "&";
            }
            constructor = constructor.Remove(constructor.Length - 1);

            HttpResponseMessage response = await client.GetAsync(new Uri(constructor)).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var stringResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(stringResult);
        }
    }
}
