# OrderService
Api for Order creation/updation/cancellation

Endpoints
POST /Order
Create a new order with the specified items.

Request Body:
{
  "customerName": "Test Customer",
  "deliveryAddress": "123 Main St",
  "items": [
    {
      "productId": "e5e6ff60-d206-4236-8394-88b3265b581c",
      "quantity": 1
    }
  ],
  "isCanceled": false,
  "orderCreatedDate": "2023-03-26T22:19:28.451Z",
  "orderUpdatedDate": "2023-03-26T22:19:28.451Z"
}

Response Body:
"Order created successfully"

PUT /Order/{orderId}/deliveryAddress
Update the delivery address for the specified order.

Parameters:
orderId  : ecf4cfc2-cfab-4876-9adb-b5692152c801

Request Body:
"ABC Main Street"

Response Body:
"Delivery address of the order ecf4cfc2-cfab-4876-9adb-b5692152c801 is updated"

PUT /Order/{orderId}/items
Update the items for the specified order.

Request Body:
[
{
    "productId": "e5e6ff60-d206-4236-8394-88b3265b581c",
    "quantity": 1
  },  
{
    "productId": "93285e94-f748-4ab8-9568-6a228dfedb7a",
    "quantity": 2
  }
]

Response Body
"Items of the order ecf4cfc2-cfab-4876-9adb-b5692152c801 is updated"

PUT /Order/{orderId}
Cancel the specified order.

Response Body:
"Order ecf4cfc2-cfab-4876-9adb-b5692152c801 is cancelled"

GET /Order/{page}/{pageSize}
Get the paged list of all the orders

Response Body
[
  {
    "orderId": "ecf4cfc2-cfab-4876-9adb-b5692152c801",
    "customerName": "Test Customer",
    "deliveryAddress": "123 Main St",
    "items": [
      {
        "id": 1,
        "productId": "e5e6ff60-d206-4236-8394-88b3265b581c",
        "quantity": 1
      }
    ],
    "isCanceled": false,
    "orderCreatedDate": "2023-03-26T22:19:28.451Z",
    "orderUpdatedDate": "2023-03-26T22:19:28.451Z"
  }
]

GET /Order/{orderId}
Get the details of a specified order

Response Body
[
  {
    "orderId": "ecf4cfc2-cfab-4876-9adb-b5692152c801",
    "customerName": "Test Customer",
    "deliveryAddress": "123 Main St",
    "items": [
      {
        "id": 1,
        "productId": "e5e6ff60-d206-4236-8394-88b3265b581c",
        "quantity": 1
      }
    ],
    "isCanceled": false,
    "orderCreatedDate": "2023-03-26T22:19:28.451Z",
    "orderUpdatedDate": "2023-03-26T22:19:28.451Z"
  }
]

Additionally the Api also handles Product/Inventory management

Endpoints
POST /Products
Create a new product with the inventory data.

Request body
{
  "name": "Product1",
  "price": 10.11,
  "inventories": [
    {
      "quantity": 30,
      "warehouseLocation": "WareHouseA"
    }
  ]
}

Response Body
"Product 3f5c1d33-1342-403a-a67c-d6c2ebdd6780 is created"

GET /Products/
Get the list of all the products.

Response Body
[
  {
    "id": "537ffa7b-5e07-4245-9d1b-06f4cddf0145",
    "name": "Product A",
    "price": 9.99,
    "inventories": [
      {
        "id": 1,
        "productId": "537ffa7b-5e07-4245-9d1b-06f4cddf0145",
        "quantity": 10,
        "warehouseLocation": "WareHouseA"
      }
    ]
  },
  {
    "id": "1b51985e-a5c1-4ad7-861c-9ee6c3e8d17f",
    "name": "Product B",
    "price": 19.99,
    "inventories": [
      {
        "id": 2,
        "productId": "1b51985e-a5c1-4ad7-861c-9ee6c3e8d17f",
        "quantity": 6,
        "warehouseLocation": "WareHouseB"
      }
    ]
  }
]

GET /Products/{Id}
gets the details of a specified product.

Response Body :

{
    "id": "1b51985e-a5c1-4ad7-861c-9ee6c3e8d17f",
    "name": "Product B",
    "price": 19.99,
    "inventories": [
      {
        "id": 2,
        "productId": "1b51985e-a5c1-4ad7-861c-9ee6c3e8d17f",
        "quantity": 6,
        "warehouseLocation": "WareHouseB"
      }
    ]
  }

GET /Inventory
Gets the list of Inventory data

Response Body:
[
  {
    "id": 5,
    "productId": "e5e6ff60-d206-4236-8394-88b3265b581c",
    "quantity": 0,
    "warehouseLocation": "WareHouseB"
  },
  {
    "id": 4,
    "productId": "6f51b34c-40f1-43ae-a87c-f5d7c27a7780",
    "quantity": 4,
    "warehouseLocation": "WareHouseA"
  },
  {
    "id": 3,
    "productId": "93285e94-f748-4ab8-9568-6a228dfedb7a",
    "quantity": 10,
    "warehouseLocation": "WareHouseC"
  },
  {
    "id": 2,
    "productId": "1b51985e-a5c1-4ad7-861c-9ee6c3e8d17f",
    "quantity": 6,
    "warehouseLocation": "WareHouseB"
  },
  {
    "id": 1,
    "productId": "537ffa7b-5e07-4245-9d1b-06f4cddf0145",
    "quantity": 10,
    "warehouseLocation": "WareHouseA"
  },
  {
    "id": 6,
    "productId": "3f5c1d33-1342-403a-a67c-d6c2ebdd6780",
    "quantity": 30,
    "warehouseLocation": "WareHouseA"
  }
]


