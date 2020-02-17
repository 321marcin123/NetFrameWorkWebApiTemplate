1.Template has installed and configured in IoC packages: 
	-Autofac
	-AutoMapper
	-Serilog
	-Swagger
2.To connect with database use IContext interface, previously edit connection strings in web.config file.
3.Feel free using GenericRepository to work with your entities. Remeber that repository use Automapper and add your maps. 
4. In IoC are registered only ApiControllers if you want to use Home, Account and Values controllers like mvc applications
use IoC code paste two lines of code :
in RegisterTypes (paragraph 2) part :
	
			// MVC controllers registration
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

and on after resolving container for web api (paragraph 4) paste :

			//5. set resolver for MVC Controllers:
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

