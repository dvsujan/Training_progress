using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace azuresecrettest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vaultUrl = "https://dvsujanvault.vault.azure.net/"; 

            var client = new SecretClient(vaultUri: new Uri(vaultUrl), credential: new DefaultAzureCredential());

            KeyVaultSecret  secret = client.GetSecret("connectionstring");
            Console.WriteLine(secret.Name);
            Console.WriteLine(secret.Value);
        }
    }
}
