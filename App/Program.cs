using App.Data;
using App.Repository;
using App.Service;
using App.UI;
using App.Validators;

using var db = new NeoGenesisContext();
db.Database.EnsureCreated();

var repository = new DinosaurRepository(db);
var validator = new DinosaurValidator(repository);
var service = new DinosaurService(repository, validator);
var menu = new ParkMenu(service);

menu.Run();
