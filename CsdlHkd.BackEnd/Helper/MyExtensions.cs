﻿using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Core.Web.Helper
{
    public static class MyExtensions
    {
        
        public static MvcHtmlString EncodedActionLinkOnlyUrl(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            string queryString = string.Empty;
            string htmlAttributesString = string.Empty;
            if (routeValues != null)
            {
                RouteValueDictionary d = new RouteValueDictionary(routeValues);
                for (int i = 0; i < d.Keys.Count; i++)
                {
                    if (i > 0)
                    {
                        queryString += "?";
                    }
                    queryString += d.Keys.ElementAt(i) + "=" + d.Values.ElementAt(i);
                }
            }

            if (htmlAttributes != null)
            {
                RouteValueDictionary d = new RouteValueDictionary(htmlAttributes);
                for (int i = 0; i < d.Keys.Count; i++)
                {
                    htmlAttributesString += " " + d.Keys.ElementAt(i) + "='" + d.Values.ElementAt(i) + "'";
                }
            }

            //What is Entity Framework??
            StringBuilder ancor = new StringBuilder();
            
            if (controllerName != string.Empty)
            {
                ancor.Append("/" + controllerName);
            }

            if (actionName != "Index")
            {
                ancor.Append("/" + actionName);
            }
            if (queryString != string.Empty)
            {
                ancor.Append("?q=" + Encrypt(queryString));
            }
            
            ancor.Append(linkText);
            ancor.Append("");
            return new MvcHtmlString(ancor.ToString());
        }
        private static string Encrypt(string plainText)
        {
            //string key = ConstKey.EncryptingKey;
            //byte[] EncryptKey = { };
            //byte[] IV = { 55, 34, 87, 64, 87, 195, 54, 21 };
            //EncryptKey = System.Text.Encoding.UTF8.GetBytes(key.Substring(0, 8));
            //DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            //byte[] inputByte = Encoding.UTF8.GetBytes(plainText);
            //MemoryStream mStream = new MemoryStream();
            //CryptoStream cStream = new CryptoStream(mStream, des.CreateEncryptor(EncryptKey, IV), CryptoStreamMode.Write);
            //cStream.Write(inputByte, 0, inputByte.Length);
            //cStream.FlushFinalBlock();
            //return Convert.ToBase64String(mStream.ToArray());
            return Common.Encrypt.EncryptAndHash(plainText);
        }
    }
}