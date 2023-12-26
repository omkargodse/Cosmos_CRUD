// See https://aka.ms/new-console-template for more information
using Cosmos_CRUD;
using Microsoft.Azure.Cosmos;

Console.WriteLine("Hello, World!");

string key = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

string URI = "https://localhost:8081";

CosmosClient client = new CosmosClient(URI, key);

Database database = await client.CreateDatabaseIfNotExistsAsync("EmployeeMaster");

Container container = await database.CreateContainerIfNotExistsAsync("EmpDetails", "/zipcode", 400);

// Create item
EmpDetails empDetails = new EmpDetails()
{
    id = Guid.NewGuid(),
    address = "Pune",
    fName = "XYZ",
    lName = "ABC",
    zipcode = "411019"
};

var x = await container.CreateItemAsync<EmpDetails>(empDetails);
PartitionKey partition = new PartitionKey("411019");

// Read item
EmpDetails t = await container.ReadItemAsync<EmpDetails>("e2f35c47-010a-49b3-a55e-d14397f6b015", partition);


// Update item
t.address = "Mumbai";

await container.UpsertItemAsync<EmpDetails>(t);
Console.WriteLine(t.address);

// Delete item
var R = await container.DeleteItemAsync<EmpDetails>(t.id.ToString(), partition);
// Console.WriteLine(x.ETag);
//Console.WriteLine(x.RequestCharge);
//Console.WriteLine(x.Headers);

Console.ReadLine();