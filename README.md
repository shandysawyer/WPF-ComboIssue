This project used a database first approach. To setup do the following:

1. Run the `InitializeSqlDbTables.sql` script in your local database.
2. scaffold the context using the following command (with permissions edited) from the COREContracts.DataAccess project:
```
Scaffold-DbContext "server=server;user=myuser;password=mypassword;database=MyDatabase" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context CoreContext -Tables CORE_Contract,CORE_Carrier -Force
```