# WebShopAPI

The Web Shop API is a RESTful API designed to provide functionality for managing articles, including displaying article information, color details, and variant information for a web shop application.

### Endpoints

The API provides the following endpoints:

#### GET /articles

This endpoint retrieves a list of articles available in the web shop.

Example Response:
```json
[
  {
    "id": 1,
    "colorInfos": [],
    "name": "Classic Poloshirt",
    "season": "202305",
    "collectionType": 10,
    "careInformation": "Gentle cycle 30 degrees, Chlorine bleach not possible",
    "fitInformation": "Fit: Regular fit, Length: 68cm",
    "materialInformation": "Fabric: Cotton, Quality: soft"
  },
  {
    "id": 2,
    "colorInfos": [],
    "name": "Slim leg Jeans",
    "season": "202301",
    "collectionType": 15,
    "careInformation": "Gentle cycle 30 degrees, Chlorine bleach not possible",
    "fitInformation": "Fit: Slim fit, Rise: Mid rise",
    "materialInformation": "Fabric: Denim, Quality: elastic"
  },
  {
    "id": 3,
    "colorInfos": [],
    "name": "Hooded Quilted Jacket",
    "season": "202209",
    "collectionType": 20,
    "careInformation": "Gentle cycle 30 degrees, Chlorine bleach not possible",
    "fitInformation": "Fit: Regular fit, Length: 58cm",
    "materialInformation": "Fabric: Woven, Quality: light, Filling: lightly padded"
  }
]
```

#### GET /articles/{id}

This endpoint retrieves detailed information about a specific article identified by its ID.

Example Response:
```json
{
  "id": 1,
  "colorInfos": [
    {
      "id": 1,
      "variantInfos": [
        {
          "id": 1,
          "ean": "2127495.5952.114/122",
          "sizeOrLengthInfo": "Size: medium, Length: 68cm, Sleeve length: short",
          "price": 13.99,
          "availableStock": 15,
          "colorInfoId": 1
        }
      ],
      "colorName": "Navy",
      "colorCode": "NVPOLO",
      "pictures": [],
      "articleId": 1
    }
  ],
  "name": "Classic Poloshirt",
  "season": "202305",
  "collectionType": 10,
  "careInformation": "Gentle cycle 30 degrees, Chlorine bleach not possible",
  "fitInformation": "Fit: Regular fit, Length: 68cm",
  "materialInformation": "Fabric: Cotton, Quality: soft"
}
```

### Getting Started

To set up and run the Web Shop API locally:

1. Clone the repository: `git clone https://github.com/paulmartinjoy/WebShopApi.git`
2. Navigate to the project directory: 
3. Build the solution: `dotnet build`
4. Run the API: `dotnet run`

The API will be available at `https://localhost:7109` by default.

### Configuration

The Web Shop API can be configured using the following environment variables:

- `DATABASE_CONNECTION_STRING`: Connection string for the database. (appsettings.json)

Make sure to set these environment variables before running the API.

### More Info

Only users with administratror rights are allowed to add articles, colorinfos and variantinfos. But inorder to make the end points work, the user has to be made an administrator manually in the database. An administrator registration endpoint can be the next step to do it. 
