using App.Data;
using App.LINKQ;
using App.Repository;
using App.Service;
using App.UI;
using App.Validators;

var context = new NeoGenesisContext();
var repository = new DinosaurRepository(context);
var validator = new DinosaurValidator();
var query = new DinosaurQueryService(context, repository);
var service = new DinosaurService(repository, validator, query);

var menu = new ParkMenu(service);
menu.Run();
