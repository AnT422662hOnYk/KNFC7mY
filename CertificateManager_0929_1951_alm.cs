// 代码生成时间: 2025-09-29 19:51:10
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Networking;

namespace SSLTLSCertificateManager
{
    public class CertificateManager
    {
        // Loads the certificate from a specified file path
        public X509Certificate LoadCertificate(string filePath)
        {
            try
            {
                // Ensure the file exists
                if (!File.Exists(filePath))
                {
                    Debug.LogError($"Certificate file not found: {filePath}");
                    return null;
                }

                // Load the certificate from the file
                byte[] certData = File.ReadAllBytes(filePath);
                X509Certificate certificate = new X509Certificate(certData);

                return certificate;
            }
            catch (Exception ex)
            {
                // Log the exception and return null if an error occurs during loading
                Debug.LogError($"Error loading certificate: {ex.Message}");
                return null;
            }
        }

        // Verifies the certificate against a remote server
        public bool VerifyCertificate(X509Certificate certificate, string serverUrl)
        {
            try
            {
                // Check if the certificate is valid
                if (certificate == null)
                {
                    Debug.LogError("No certificate provided for verification.");
                    return false;
                }

                // Create a UnityWebRequest to the server and attach the certificate
                using (UnityWebRequest www = UnityWebRequest.Get(serverUrl))
                {
                    www.uploadHandler = new UploadHandlerRaw(new byte[0]);
                    www.downloadHandler = new DownloadHandlerBuffer();
                    www.certificateHandler = new CertificateHandler();
                    www.certificateHandler.ServerCertificateValidationCallback = (req, cert, chain, errors) => {
                        return cert.Equals(certificate);
                    };

                    // Send the request and wait for the response
                    yield return www.SendWebRequest();

                    if (www.isNetworkError || www.isHttpError)
                    {
                        Debug.LogError(www.error);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception and return false if verification fails
                Debug.LogError($"Error verifying certificate: {ex.Message}");
                return false;
            }
        }
    }
}
