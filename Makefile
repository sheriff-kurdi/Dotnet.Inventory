run:
	cd src/Kurdi.Inventory.Api;dotnet run

publish:
	cd src/Kurdi.Inventory.Api;dotnet publish -o ../../build     

test:
	cd tests/Kurdi.Inventory.UnitTest;dotnet test --logger "console;verbosity=normal" 

docker.build: 
	docker build -t $(name) .	