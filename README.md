# Open-Lyrics
Server side API written in .NET Core and client side SPA application written in Angular 8
## How to run the application (both BE&FE) locally

### Prerequisites to run the backend app
- You need .NET Core 3.1 installed on your machine
- You need SQL server (Express edition or higher)
- You need Redis (https://redislabs.com/blog/redis-on-windows-10/ here is tutorial how to install Redis locally for Windows)

#### Steps
1. Open LyricsAPI.sln file with VS2019 or VSCode
2. Build the project inside it
3. Run the Sandbox project (it will seed data including an user)
4. Run the WebAPI project (ctrl+F5) to start the app locally.
5. Should be up and running on https://localhost:5001

### Prerequisites to run the Angular app
     _                      _                 ____ _     ___
    / \   _ __   __ _ _   _| | __ _ _ __     / ___| |   |_ _|
   / △ \ | '_ \ / _` | | | | |/ _` | '__|   | |   | |    | |
  / ___ \| | | | (_| | |_| | | (_| | |      | |___| |___ | |
 /_/   \_\_| |_|\__, |\__,_|_|\__,_|_|       \____|_____|___|
                |___/


Angular CLI: 8.3.24
Node: 12.14.1

#### Steps
1. Go to client\lyrics-spa
2. run npm install
3. run ng serve 
4. App should be up and running on http://localhost:4200/

