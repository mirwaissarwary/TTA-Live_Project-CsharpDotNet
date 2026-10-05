# Rental request source slice

This folder is a **reviewable slice** of the Theatre Vertigo rental-request feature. It is here so a portfolio reader can inspect the code. It is **not** a project you can build or run on its own.

## What is included

- `Controllers/RentalRequestsController.cs` — CRUD, Index sort by start time, and the 7-day expiry rule
- `Models/RentalRequest.cs` — the rental-request entity
- `Views/RentalRequests/` — Index, Create, Edit, Details, and Delete
- `Content/Rent.css` and `Scripts/Rent.js` — area styles and the current/expired toggle
- `RentAreaRegistration.cs` — maps `/Rent/{controller}/{action}/{id}`

The copies of `Index.cshtml` and `Create.cshtml` include the local `Url.Action` fix: **Create New** and **Back to List** pass `area = "Rent"` so the browser does not drop the Rent prefix.

## What is left out

No `TheatreCMS3.sln`, no `Web.config`, no connection strings, no Identity, and no teammate areas. Other Rent controllers (histories, rentals, surveys) are not part of this slice.

`Rent.css` still has a few shared Rent-area rules that lived in the same stylesheet (including survey-form placeholders). They stayed with the file rather than being split out.

## Why it will not build alone

The controller constructs `TheatreCMS3.Models.ApplicationDbContext` and uses `db.RentalRequests`. The views set `Layout = "~/Views/Shared/_Layout.cshtml"` and render site script bundles. Those types, the layout, and the database live in the full TheatreCMS3 solution, which is not published here.

To run the feature, open that local solution in Visual Studio, point `Web.config` at your own database, and browse `/Rent/RentalRequests`. Keep connection strings off GitHub.
