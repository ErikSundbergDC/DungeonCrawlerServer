**DungeonCrawler, uppgifter att jobba med.**

Jobba med en uppgift i taget. Innan du går vidare till nästa så testa noggrant att allt fungerar som det ska. Gör sedan ”Commit All and Sync” mot Github. Skriv uppgiftens nummer i ”message”-fönstret och även om du löst den helt, delvis eller bara börjat jobba med den. Vissa uppgifter bygger på att tidigare steg är genomförda. Fler uppgifter kan tillkomma senare.

1.	Lägg till CommandWest, dvs ett kommando för att gå västerut.
2.	Lägg till CommandNorth, dvs ett kommando för att gå norrut.
3.	Lägg till CommandSouth, dvs ett kommando för att gå söderut.
4.	Lägg till CommandQuit. Kommandot ska skriva ut ett avskedsmeddelande och sedan avslutas programmet genom att Perform()-metoden returnerar true.
  a.	Lägg till ett ”alias” för CommandQuit som gör så att samma kod anropas även om man skriver ”exit”. (Det finns ett mycket enkelt sätt att göra detta, men du får fundera lite på det själv.)
5.	Lägg till CommandCommands som är ett kommando för att lista alla kommandon och skriva ut dem på skärmen. Använd dig av en foreach-loop för att gå igenom alla kommandon som finns i PlayerCharacterns lista.
6.	Lägg till en hjälptext till varje kommando. Gör detta som en abstract property av typen string på klassen BaseCommand som du sedan implementerar så att den returnerar olika hjälptexter för de olika kommandona.
  a.	Lägg till CommandHelp som fungerar som CommandCommands fast det skriver även ut hjälptexten för alla kommandon.
7.	Lägg till CommandStatus som är ett kommando som visar spelarens HealthPoints. Även MaxHealthPoints ska visas. Det kan tex se ut så här:

    Health: 100/200

8.	Lägg till en klass som heter ”Item” och representerar föremål i spelet. Klassen ska ärva från GameObject och ha egenskaperna (properties) Name, Description och Weight. Testa att klassen funkar genom att skapa objekt av den i metoden World.Create().
  a.	Se till att klassen Room har en lista för de Items som rummet innehåller. Listan ska se ut och fungera på samma sätt som listan för Characters. 
  b.	Skapa ett ”Inventory” för alla BaseCharacter, dvs en lista över de föremål som spelaren/monstret bär på.
  c.	Lägg till kommandot CommandInventory som listar alla Items som finns i spelarens Inventory.
  d.	Lägg till kommandot CommandGet som används för att plocka upp föremål som finns i ett rum. Detta kommando ska alltså ta bort ett item från rummets lista samtidigt som det lägger till det i spelarens Inventory. Lägg själva koden för att åstadkomma detta i en metod som heter GetItemFromRoom() i klassen BaseCharacter så att även NonPlayerCharacters teoretiskt sett kan ta upp föremål. Anropa sedan GetItemFromRoom() från     CommandGet:s Perform()-metod. Titta på CommandAttack för lite hjälp med hur du ska göra för att hitta rätt Item i listan.
  e.	Lägg till kommandot CommandDrop som gör tvärtom mot CommandGet, dvs Items som finns i spelarens Inventory placeras i stället i det rum där man befinner sig.
9.	Lägg till en egenskap ”MaxInventoryWeight” som är av typen int på BaseCharacter. Denna egenskap ska styra hur mycket vikt som kan finnas i spelarens/monstrets inventory. Man ska inte kunna plocka upp ett Item med CommandGet från ett rum om detta gör så att den sammanlagda vikten av spelarens inventory överstiger MaxInventoryWeight.
  a.	Gör så att CommandStatus även visar den sammanlagda vikten för spelarens Inventory och MaxInventoryWeight, tex så här:
      Inventory: 32/50
  	
11.	Lägg till en klass som heter Food. Denna klass ska ärva från Item och ha en ytterligare egenskap (property) som är av typen int och heter HpRegeneration. Testa att klassen funkar genom att skapa objekt av den i metoden CreateWorld och lägg till dessa i något rum.
  a.	Lägg till CommandEat. Detta kommando ska ta bort ett item som är av typen Food från spelarens inventory samtidigt som det ökar spelarens HealthPoints lika mycket som HpRegeneration anger, dock som mest upp till spelarens MaxHealthPoints.
12.	Lägg till en klass som heter Container. Denna klass ska ärva från Item och fungera som en väska eller något liknande där man kan förvara andra Items. För att konstruera denna klass kommer du behöva fundera lite på vilka metoder och egenskaper den behöver ha och hur det ska gå till att placera föremål i containern och ta föremål från den.
13.	Förbättra CommandAttack och Fight-systemet i spelet så att det blir mer avancerat och informativt och inte bara bygger på slump. Gör så att fighterna körs i omgångar tills någons healthpoints når 0 och man som spelare har möjlighet att välja att fly efter varje omgång. Eller hitta på något annat system du tror kommer funka och kanske till och med har lite inslag av skicklighet?
14.	Lägg till en klass som heter AggressiveNonPlayerCharacter och ärver från NonPlayerCharacter. Om spelaren går in i ett rum där det finns ett aggressivt monster så ska monstret genast attackera spelaren.
15.	Utöka klassen BaseCharacter med en egenskap ”Description” som är en string som innehåller en längre beskrivning av monstret/spelarens utseende.
  a.	Utöka CommandLook så att man kan använda det för att titta på monster/spelare och då se deras Description.
  b.	Lägg till kommandot CommandDescription som kan användas både ensamt (då visar det spelarens egen Description) eller med en text efteråt (då sätter den spelarens Description till att bli denna text.
16.	Lägg till dörrar mellan vissa rum som går att öppna och stänga med kommandona CommandOpen och CommandClose. För att lösa detta på ett bra sätt krävs troligen att man lägger till minst en klass till som håller reda på ”Exits” på något sätt.
  a.	Lägg även till låsbara dörrar som kan låsas upp när man har ett särskilt Item (nyckel) i sitt Inventory. Kommandona som ska finnas är CommandUnlock för att låsa upp en dörr och CommandLock för att låsa en dörr.
17.	Lägg till en klass som heter MagicalItem. Denna klass ska ärva från Item och ge bäraren extra egenskaper, tex mer hp eller på andra sätt större chanser att lyckas i en strid. Du behöver säkert lägga till kod på flera olika ställen för att få det att fungera som du vill.
18.	Gör så att spelet får ett slut! Kanske i form av en slutboss (extra svår fiende) som man behöver besegra för att vinna?
