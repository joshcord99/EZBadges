# EZBadges
 
This app gives the ability to add employee information from the CLI or pull from a company API to create employee badges. This app was built using **C#**.


## Tools and Technologies Used:


**.NET Core SDK**
   - The **Software Development Kit (SDK)** for .NET Core includes:
   - Purpose: 
       - Enabled reading and writing to the file system, querying APIs, and generating images.
    
**SkiaSharp**
   - A **.NET package** that provides powerful graphics functionality.
   - Purpose:
     - Modify and manipulate images.
     - Generate visually appealing security badges.

**Random User Generator API**
   - A free, open-source API for generating random user data.
   - Data provided:
     - Names.
     - IDs.
     - Thumbnail photos.
   - This API will supply the data for creating personalized security badges.

**Newtonsoft.Json**
   - A popular library for working with JSON in .NET.
   - Used to parse and process JSON data from the Random User Generator API to extract user information.

## How to Install
 1. Clone the repository locally
 2. Install .NET SDK
 3. Navigate to project root
 4. Restore dependecies with `dotnet restore`
 5. When your ready to start making badges, open the CLI and run `dotnet run
`


