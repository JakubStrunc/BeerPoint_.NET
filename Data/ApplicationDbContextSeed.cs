using PNET_semestralka_blazor_app.Data;
using PNET_semestralka_blazor_app.Models;

public static class ApplicationDbContextSeed
{
    public static void SeedData(ApplicationDbContext context)
    {
        // Automaticky vygeneruje databázi, pokud neexistuje
        context.Database.EnsureCreated();

        // Pokud už jsou data, ukonči
        if (context.Users.Any()) return;

        // Prodejce
        var seller = new Seller
        {
            UzivatelskeJmeno = "pivnice123",
            Email = "pivo@shop.cz",
            Heslo = "heslo123",
            Products = new List<Product>()
        };

        // Zákazník
        var customer = new Customer
        {
            UzivatelskeJmeno = "jan.novak",
            Email = "jan@novak.cz",
            Heslo = "tajneheslo",
            ShippingDetails = new List<SendingAddress>(),
            Orders = new List<Order>()
        };

        // Adresa zákazníka
        var address = new SendingAddress
        {
            Jmeno = "Jan",
            Prijmeni = "Novák",
            Ulice = "Hlavní",
            PopisneCislo = 25,
            OrientacniCislo = 8,
            Mesto = "Praha",
            Psc = 11000,
            Customer = customer
        };

        // Produkty
        var products = new List<Product>
        {
            new Product
            {
                Nazev = "Birell Pomelo & Grep - sud",
                Cena = 850,
                Mnozstvi = 25,
                Popis = "Nealkoholický sudový Birell s příchutí pomelo a grep",
                Photo = "Birell_Pomelo&Grep_sud.jpg",
                Seller = seller
            },
            new Product
            {
                Nazev = "Gambrinus 10° - přepravka",
                Cena = 289,
                Mnozstvi = 60,
                Popis = "Gambrinus 10° ve vratné přepravce, 20x0.5l",
                Photo = "gambrinus_10_prepravka.jpg",
                Seller = seller
            },
            new Product
            {
                Nazev = "Gambrinus 11° - přepravka",
                Cena = 299,
                Mnozstvi = 50,
                Popis = "Gambrinus 11° ve vratné přepravce, 20x0.5l",
                Photo = "gambrinus_11.jpg",
                Seller = seller
            },
            new Product
            {
                Nazev = "Gambrinus 12° - přepravka",
                Cena = 319,
                Mnozstvi = 45,
                Popis = "Gambrinus 12° ve vratné přepravce, 20x0.5l",
                Photo = "gambrinus_12_prepravka.jpg",
                Seller = seller
            },
            new Product
            {
                Nazev = "Gambrinus - láhev",
                Cena = 25,
                Mnozstvi = 120,
                Popis = "Gambrinus světlý ležák v klasické láhvi 0.5l",
                Photo = "gambrinus.jpg",
                Seller = seller
            },
            new Product
            {
                Nazev = "Kozel - přepravka",
                Cena = 279,
                Mnozstvi = 70,
                Popis = "Kozel světlý ležák v přepravce, 20x0.5l",
                Photo = "kozel_prepravka.jpg",
                Seller = seller
            },
            new Product
            {
                Nazev = "Kozel - sud 30L",
                Cena = 999,
                Mnozstvi = 30,
                Popis = "Sud piva Kozel 11° vhodný na oslavy",
                Photo = "kozel_sud.jpg",
                Seller = seller
            },
            new Product
            {
                Nazev = "Excelent 11° - láhev",
                Cena = 28,
                Mnozstvi = 85,
                Popis = "Hořké pivo Excelent 11° v 0.5l lahvi",
                Photo = "exelent.jpg",
                Seller = seller
            },
            new Product
            {
                Nazev = "Pilsner Urquell 12° - přepravka",
                Cena = 349,
                Mnozstvi = 55,
                Popis = "Originální Plzeňský ležák ve vratné přepravce",
                Photo = "pilsner.jpg",
                Seller = seller
            }
        };

        context.Products.AddRange(products);

		// Objednávka
		var orders = new List<Order>
        {
	        new Order
	        {
		        Jmeno = address.Jmeno,
		        Prijmeni = address.Prijmeni,
		        Ulice = address.Ulice,
		        PopisneCislo = address.PopisneCislo,
		        OrientacniCislo = address.OrientacniCislo,
		        Mesto = address.Mesto,
		        Psc = address.Psc,
		        Customer = customer,
		        Stav = "Košík",
		        OrderItems = new List<OrderItem>
		        {
			        new OrderItem
			        {
				        Product = products[0],
				        Pocet = 4
			        },
			        new OrderItem
			        {
				        Product = products[1],
				        Pocet = 2
			        }
		        }
	        },
	        new Order
	        {
		        Jmeno = address.Jmeno,
		        Prijmeni = address.Prijmeni,
		        Ulice = address.Ulice,
		        PopisneCislo = address.PopisneCislo,
		        OrientacniCislo = address.OrientacniCislo,
		        Mesto = address.Mesto,
		        Psc = address.Psc,
		        Customer = customer,
		        Stav = "Doručena",
		        OrderItems = new List<OrderItem>
		        {
			        new OrderItem
			        {
				        Product = products[2],
				        Pocet = 1
			        },
			        new OrderItem
			        {
				        Product = products[3],
				        Pocet = 3
			        },
			        new OrderItem
			        {
				        Product = products[4],
				        Pocet = 6
			        }
		        }
	        }
        };

		context.Orders.AddRange(orders);

		// Uložení do databáze
		context.Users.Add(seller);
        context.Users.Add(customer);
        context.SendingAddress.Add(address);
        context.SaveChanges();
    }

}




