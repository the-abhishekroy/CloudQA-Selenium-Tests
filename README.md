# CloudQA Selenium Test Suite

Complete automated test solution for CloudQA developer internship application.

## Quick Start

```powershell
cd X:\ii\CloudQA.SeleniumTests
dotnet restore
dotnet build
dotnet test
```

## What's Tested

✅ **First Name** field - Text input validation  
✅ **Email** field - Email format input validation  
✅ **Mobile Number** field - Phone number validation  

## Resilience Features

Each test uses **5 fallback locator strategies** to keep working even if:
- Element IDs, classes, or names change
- Element positions in the DOM change
- Page structure is modified

See [README.md](CloudQA.SeleniumTests/DOCUMENTATION.md) for full documentation.
