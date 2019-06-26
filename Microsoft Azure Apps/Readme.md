# Deploying to Azure
**Author:** Sam Amara
**Date:** 6/26/19

## Photo Hosting:
For convenience, I chose to store uploaded user photos directly on Azure. In order to add a profile photo or add photos to albums, Journey uses a Web API to load the images on Azure Blob Storage. Once a photo is loaded, a function triggers to create a thumbnail. Below the steps to enable these features:

### Step 1: Create a Storage Account
 - Create a new Azure Storage Account (suggested name: JourneyPhotoStore)
 - Under Blobs Create two containers "images" and "images-thumbnails"
 - For the Public access level setting, select "Blob (anonymous read access...)" 
 - Under access keys copy the Connection String

### Step 2: Deploy the Web API
 - Create a new Azure Web App (suggested name: JourneyPhotoAPI)
 - Under Configuration add a New application setting named "StorageConnectionString"
 - For the value, paste the Connection String copied in Step 1
 - From your local machine, deploy the API.zip file (provided in this folder) using AZURE POWERSHELL and the following command: 
 
 az webapp deployment source config-zip --resource-group [Replace_With_Resource_Group_Name] --src api.zip --name [Replace_With_Web_App_Name]
 
### Step 3: Create Azure Function to process thumbnails
 - Create a new Azure Function App  (suggested name: JourneyThumbsFunc)
 - Refer to "FuncAppInstructions.pdf" and "function.proj" (provided in this folder) to create the app
 
## Journey Web Hosting:
  - Using Visual Studio Journey Web App can be published to Azure in minutes
  - You will need to create an Azure SQL Server to host the JourneyDB SQL database
  - Under Configuration add a New connection string named "JourneyDB"
  - For the value, use the Connection String for the Azure SQL Server created earlier