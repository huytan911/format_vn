# Format Shop

## Prerequisites

- .NET 9.0 SDK
- Node.js & npm
- MySql Server (8.0+)

## Getting Started

### 1. Database Setup

Ensure you have a MySql server running.
Create a database named `formatvn_shop`.

```sql
CREATE DATABASE formatvn_shop;
```

Update the connection string in `FormatVnShop/appsettings.json` if your credentials differ from the default:
`server=localhost;user=root;password=password;database=formatvn_shop`

### 2. Backend (API)

Navigate to the `FormatVnShop` directory:

```bash
cd FormatVnShop
```

Run the application:

```bash
dotnet run
```

The API will start at `http://localhost:5149`.
The database tables will be automatically created and seeded on the first run.

### 3. Frontend (React)

Open a new terminal and navigate to the `frontend` directory:

```bash
cd frontend
```

Install dependencies:

```bash
npm install
```

Start the development server:

```bash
npm run dev
```

The application will be available at `http://localhost:5173`.
