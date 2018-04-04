Enable-Migrations -ProjectName Data.Migration -StartUpProjectName AngularWorkshop -ContextProjectName Data -ContextTypeName StoreContext -ConnectionStringName store

Add-Migration -ProjectName Data.Migration -StartUpProjectName AngularWorkshop -Name AddedFewThingsToArticle

Update-Database -ProjectName Data.Migration -StartUpProjectName AngularWorkshop -ConfigurationTypeName Configuration

