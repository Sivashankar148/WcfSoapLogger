﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WcfSoapLogger;

namespace Service
{
    public class Database : IDatabase
    {
        private const string LogDirectory = @"C:\SoapLogCustomService";

        public JuiceInfo[] FindSimilar(JuiceInfo juice)
        {
            Console.WriteLine(juice.Id + ": received.");
            
            byte[] requestBody;
            SoapLoggerSettings settings;

            //should be on the very top of method
            SoapLoggerForService.ReadRequestSetResponseCallback(out requestBody, out settings, ResponseCallback);


//            throw new InvalidOperationException("Problem in Service - FindSimilar");

            if (requestBody != null)
            {
                SoapLoggerTools.WriteFileDefault(requestBody, true, LogDirectory);
            }

            var context = OperationContext.Current;

            var result  = new JuiceInfo[]
            {
                new JuiceInfo()
                {
                    Id = juice.Id,
                    Name = "Happy apple",
                    Location = "Warehouse Zeta",
                    Price = 430
                },
                new JuiceInfo()
                {
                    Id = 8,
                    Name = "Wonderful carrot",
                    Location = "Warehouse Lambda",
                    Price = 575
                },
            };

            Console.WriteLine(juice.Id + ": returning. Count: " + result.Length);
            return result;
        }

        private void ResponseCallback(byte[] responseBody, SoapLoggerSettings settings)
        {
//            throw new InvalidOperationException("Problem in Service - ResponseCallback.");
            SoapLoggerTools.WriteFileDefault(responseBody, false, LogDirectory);
        }




//        public static string GetRequestId(XmlDocument xmlDoc) {
//            XmlNode node = SoapLoggerTools.FindNodeByPath(xmlDoc, "Envelope", "Body", "SendProduct", "metadata", "RequestMessageId");
//
//            if (node == null)
//            {
//                node = SoapLoggerTools.FindNodeByPath(xmlDoc, "Envelope", "Body", "SendProductResponse", "SendProductResult", "RequestMessageId");
//            }
//
//            if (node == null)
//            {
//                node = SoapLoggerTools.FindNodeByPath(xmlDoc, "Envelope", "Body", "SendClustersData", "metadata", "RequestMessageId");
//            }
//
//            if (node == null)
//            {
//                node = SoapLoggerTools.FindNodeByPath(xmlDoc, "Envelope", "Body", "SendClustersDataResponse", "SendClustersDataResult", "RequestMessageId");
//            }
//
//            if (node == null)
//            {
//                return null;
//            }
//
//            return node.InnerText;
//        }
//
//
//        public static string GetProductIdentifier(XmlDocument xmlDoc) {
//            XmlNode node = SoapLoggerTools.FindNodeByPath(xmlDoc, "Envelope", "Body", "SendProduct", "product", "ProductIdentifier");
//
//            if (node == null)
//            {
//                return null;
//            }
//
//            return node.InnerText;
//        }
    }
}
