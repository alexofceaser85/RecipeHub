# RecipeHub
Welcome to RecipeHub! This is a capstone project for our group at University of West Georgia. The purpose of this system is to act as a tool to find recipes for a user's ingredients they have inputted into the system.

See below for setup instructions.

## Setup Instructions
1. Clone Project to Visual Studio
2. Publish Database using Database.publish.xml in PublishScripts folder of Database.
3. Open `Database>PopulateDB.sql`, then run the script with `ctrl+shift+e` to clear the database and load dummy data.
   - Dummy data includes three users: `MasterChef`, `Onion_King`, and `hotlava77`. Each have different pantries, and all thre use `password` for their password.
   - If you don't want to load the dummy data, manually add the following rows to the `MeasurementTypes` table:
     - typeId - name
     - 1 - Quantity
     - 2 - Mass
     - 3 - Volume
5. Run Server
6. Run Either Desktop Client or Web Client
