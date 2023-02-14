USE CigarShop

-- Table: Sizes
SET IDENTITY_INSERT Sizes ON

INSERT INTO Sizes (Id, Length, RingRange) VALUES
(1, 10, 1.8),
(2, 10, 2.9),
(3, 10, 3.2),
(4, 12, 3.6),
(5, 10, 7.3),
(6, 11, 5.3),
(7, 13, 6.5),
(8, 15,5.1),
(9, 14, 3.4),
(10, 10, 2.1),
(11, 18,1.5),
(12, 22, 6.9),
(13, 17, 7.5),
(14, 14, 6.5),
(15, 11, 4.3),
(16, 18, 5.9),
(17, 19, 4.1),
(18, 20, 3.9),
(19, 13, 4.4),
(20, 15, 5.5),
(21, 16, 6.6),
(22, 18, 1.9),
(23, 19, 5.2),
(24, 20, 5.9),
(25, 20, 4.6),
(26, 25, 2.1),
(27, 17, 2.9),
(28, 18, 6.4),
(29, 13, 7.1),
(30, 16, 5.8)

SET IDENTITY_INSERT Sizes OFF

-- Table: Tastes
SET IDENTITY_INSERT Tastes ON

INSERT INTO Tastes (Id, TasteType, TasteStrength, ImageURL) VALUES
(1,'Spicy','Full', 'menu_strength_full.png'),
(2,'Earthy', 'Medium to Full', 'menu_strength_medium_full.png'),
(3,'Woody','Medium', 'menu_strength_medium.png'),
(4,'Fruity', 'Light to Medium', 'menu_strength_ligth_medium.png'),
(5,'Vegetal', 'Light', 'menu_strength_ligth.png')


SET IDENTITY_INSERT Tastes OFF

-- Table: Brands
SET IDENTITY_INSERT Brands ON

INSERT INTO Brands (Id, BrandName, BrandDescription) VALUES
(1,'QUAI-DORSAY','Quai dOrsay is the name of a premium cigar brand, produced on the island of Cuba for Habanos SA'),
(2,'TRINIDAD', 'Trinidad is a Cuban brand of cigars, named for the city of Trinidad. Cigars are manufactured in Cuba by Habanos S.A.'),
(3,'SAN-CRISTOBAL','San Cristobal de la Habana is the name of a Cuban cigar brand produced in Cuba for Habanos SA, the Cuban state-owned tobacco company.San Cristobal de la Habana was officially launched in Havana on November 20, 1999. It was named after the original name of Havana which dates back to the 16th century.'),
(4,'ROMEO-Y-JULIETA', 'Romeo y Julieta is a brand of premium cigars, currently owned by Imperial Brands. Cigars are currently owned by two Imperial Brands subsidiaries, Habanos S.A.'),
(5,'RAMON', 'Ramón Allones is the name of two premium cigar brands, one produced on the island of Cuba for Habanos SA, the Cuban state-owned tobacco company, and other produced in Honduras for General Cigar Company, now a subsidiary of Swedish Match.'),
(6,'DAVIDOFF', 'Davidoff is a Swiss premium brand of cigars, cigarettes and smoker accessories. The Davidoff cigarette brand has been owned by Imperial Brands after purchasing it in 2006.'),
(7,'QUINTERO-BREVAS', 'Quintero is a brand of premium cigars, owned by British conglomerate Imperial Brands. The brand is produced in Cuba by Habanos S.A., the local state-owned tobacco company, which also owns the brands Cohiba, Montecristo, and Romeo y Julieta.'),
(8,'BOLIVAR', 'Bolívar is the name of two brands of premium cigar, one produced on the island of Cuba for Habanos SA, the Cuban state-owned tobacco company, and the other produced in the Dominican Republic from Dominican and Nicaraguan tobacco for General Cigar Company, which is today a subsidiary of Scandinavian Tobacco Group. Both are named for the South American revolutionary, Simón Bolívar.'),
(9,'COHIBA', 'Cohiba is a brand for two kinds of premium cigar, one produced in Cuba for Habanos S.A., the Cuban state-owned tobacco company, and the other produced in the Dominican Republic for US-based General Cigar Company. The name cohíba derives from the Taíno word for tobacco.The Cuban brand is filled with tobacco that comes from the Vuelta Abajo region of Cuba which has undergone an extra fermentation process. Cuban Cohiba was established in 1966 as a limited production private brand supplied exclusively to Fidel Castro and high-level officials in the Communist Party of Cuba and Cuban government.Often given as diplomatic gifts, the Cohiba brand gradually developed a cult status.'),
(10,'CUABA', 'Cuaba is the name of a Cuban cigar brand produced in Cuba for Habanos SA, the Cuban state-owned tobacco company.'),
(11,'DIPLOMATICOS', 'Diplomáticos is the name of a premium cigar brand, produced on the island of Cuba for Habanos SA, the Cuban state-owned tobacco company, at the José Martí factory in Havana.'),
(12,'EL-REY-DEL-MUNDO', 'El Rey del Mundo is the name of two premium cigar brands, one produced on the island of Cuba for Habanos SA, the Cuban state-owned tobacco company, and other produced in Honduras by the Villazon family.'),
(13,'FONSECA', 'Fonseca is the name of two brands of premium cigar, one produced on the island of Cuba for Habanos SA, the Cuban state-owned tobacco company, and the other produced in Nicaragua by Don Pepin Garcia My Father Cigar brand.'),
(14,'HOYO-DE-MONTERREY', 'Hoyo de Monterrey is the name of two brands of premium cigar, one produced on the island of Cuba for Habanos SA, the Cuban state-owned tobacco company and the other produced in Honduras by General Cigar Company, now a subsidiary of Swedish Match.'),
(15,'H.UPMANN', 'H. Upmann is a Cuban brand of premium cigars established by banker Hermann Dietrich Upmann (who also founded the H.Upmann & Co. bank in the island). The brand is currently owned by British corporation Imperial Brands.'),
(16,'JOSE-L.-PIEDRA', null),
(17,'JUAN-LOPEZ', null),
(18,'MONTECRISTO', 'Montecristo a brands of premium cigars and cigarrettes, produced in Cuba by Habanos S.A., the local tobacco company, and in La Romana, Dominican Republic by Altadis, a subsidiary of British conglomerate Imperial Brands.
In July 1935, Alonso Menéndez purchased the Particulares Factory, makers of the popular Particulares brand and the lesser-known Byron. Immediately after its acquisition, he created a new brand named Montecristo.
The name for the brand was inspired by the Alexandre Dumas, père novel The Count of Monte Cristo, which was supposedly a very popular choice among the torcedores (cigar rollers) in their factory to have read by the lector on the rolling floor. The now-famous Montecristo logo, consisting of a triangle of six swords surrounding a fleur-de-lis, was designed by John Hunter Morris and Elkan Co. Ltd., the brand''s British distributor.
In July 1936, Menéndez founded a new firm with a partner, naming it Menéndez, García y Cía. With the growing success of the Montecristo brand, the firm purchased the faltering H. Upmann Factory (created by Hermann Dietrich Upmann in 1844) from J. Frankau SA in 1937 and transferred Montecristo production there. J. Frankau continued as sole distributor of the H. Upmann brand in the UK, while John Hunter Morris and Elkan Co. Ltd. was the sole distributor of Montecristo in Britain. In 1963, these firms merged to become Hunters & Frankau, which today is the sole importer and distributor of all Cuban cigars in the UK.
Through the efforts of Alfred Dunhill (the company), the Montecristo brand became incredibly popular worldwide and to this day accounts for roughly one-quarter of Habanos SA''s worldwide cigar sales, making it the most popular Cuban cigar in the world. Menéndez and García fled during the Cuban Revolution, and on September 15, 1960, after which the Montecristo brand, the factory, and all assets were nationalized by the government of Fidel Castro.
Menéndez and García re-established their brand in the Canary Islands, but were later forced to quit due to trademark disputes with Cubatabaco (later known as Habanos S.A.). In the mid-1970s, the operation was moved to La Romana and released for the US market, since Cuban government rights to the brand were not recognized under American law due to the 1960 nationalization and subsequent embargo. Menéndez, García, y Cía is now owned by Altadis S.A., who controls its distribution and marketing in the United States.
With Menendez and Garcia gone after 1959, one of the top grade torcedores, José Manuel González, was promoted to floor manager and proceeded to breathe new life into the brand. In the 1970s and 1980s, five new sizes were added: the A, the Especial No. 1 and 2, the Joyita, and the Petit Tubo. Three other sizes, the Montecristo No. 6, No. 7, and B, were released but subsequently discontinued, though the B can occasionally be found in very small releases each year in Cuba. Through the 1970s and 1980s, Montecristo continued to rise in popularity among cigar smokers, becoming one of Cuba''s top selling cigar lines.'),
(19, 'PUNCH', null)

SET IDENTITY_INSERT Brands OFF

-- Table: Cigars
SET IDENTITY_INSERT Cigars ON

INSERT INTO Cigars (Id, CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL) VALUES
(1,'BOLIVAR CORONAS JUNIOR', 8, 1, 1, 17.34,'bolivar-coronas-junior.jpg'),
(2,'BOLIVAR PETIT CORONAS', 8, 3, 2, 18.76,'bolivar-petit-coronas.png'),
(3,'COHIBA 1966 EDICION LIMITADA 2011', 9, 3, 29, 19.45,'cohiba-siglo-i-stick_18.png'),
(4,'COHIBA BEHIKE 52', 9, 4, 28, 20.87,'cohiba-esplendidos-stick.jpg'),
(5,'COHIBA BEHIKE 54', 9, 5, 27, 254.09,'cohiba-esplendidos-stick.jpg'),
(6,'COHIBA BEHIKE 56', 9, 1, 26, 23.02,'cohiba-talisman-edicion-limitada-2017-1.jpg'),
(7,'COHIBA MADURO 5 GENIOS', 9, 2, 10, 66.56,'COHIBA-le-hoyo-de-san-juan-stick_9.jpg'),
(8,'HOYO-DE-MONTERREY DOUBLE CORONAS', 14, 3, 11, 23.42,'HOYO-DE-MONTERREY-siglo-tuboc-1.jpg'),
(9,'HOYO-DE-MONTERREY EPICURE NO. 2', 14, 4, 12, 78.57,'HOYO-DE-MONTERREY-siglo-i-stick_18.jpg'),
(10,'HOYO-DE-MONTERREY EPICURE ESPECIAL', 14, 5, 13, 98.89,'HOYO-DE-MONTERREY-siglo-i-stick_18.jpg'),
(11,'H.UPMANN NO. 2', 15, 4, 1, 5.45,'h-upmann-magnum-50_6_4_1_9.png'),
(12,'H.UPMANN MAGNUM 46', 15, 2, 15, 543.23,'h-upmann-magnum-0_6_4_1_9.png'),
(13,'H.UPMANN MAGNUM 50 TUBOS', 15, 3, 15, 23.66,'h-upmann-magnum-60_6_4_1_9.jpg'),
(14,'ROMEO-Y-JULIETA FABULOSOS NO. 2 - HABANOS COLECCIÓN 2016 BOOK', 4, 4, 16, 95.77,'ROMEO-Y-JULIETA-no.-4.jpg'),
(15,'COHIBA SIGLO VI GRAN RESERVA 2003', 9, 5, 17, 34.78,'COHIBA SIGLO-open-junior_1_1_2_1_1_1_4_1_1_1_1_1_1_1_1_2_4_1_9.jpg'),
(16,'H.UPMANN NO. 2 RESERVA COSECHA 2010', 15, 5, 18, 29.77,'H.UPMANN-le-hoyo-de-san-juan-stick_9.jpg'),
(17,'VEGUEROS TAPADOS', 14, 4, 1, 15.62,'VEGUEROS-open-junior_1_1_2_1_1_1_4_1_1_1_1_1_1_1_1_2_4_1_9.jpg'),
(18,'TRINIDAD CASILDA COLECCION HABANOS 2019', 2, 3, 19, 756.82,'TRINIDAD-2014-stick.jpg'),
(19,'TRINIDAD MEDIA LUNA', 2, 2, 2, 68.22,'TRINIDAD-2018-stick.jpg'),
(20,'SAN-CRISTOBAL LA FUERZA', 3 ,1 , 3, 45.12,'SAN-CRISTOBAL-small-club-corona_1_1_2_1_1_1_1_1_1_1_1_1_2_4_1_9.jpg'),
(21,'TRINIDAD MEDIA 2', 2, 5, 30, 618.22,'TRINIDAD-2009-stick.jpg'),
(22,'SAN-CRISTOBAL JARRA TORREON', 3, 5, 4, 86.32,'SAN-CRISTOBAL-small-club-corona_1_1_2_1_1_1_4_1_1_1_1_1_1_1_1_2_4_1_9.jpg'),
(23,'DAVIDOFF SIGNATURE NO.2 TUBOS', 6, 4, 5, 234.89,'DAVIDOFF-fabulosos-no.-2-2016-4.jpg'),
(24,'DAVIDOFF MILLENNIUM BLEND ROBUSTO', 6, 3, 6, 86.45,'DAVIDOFF-la-fuerza-1.jpg'),
(25,'RAMON ALLONES SMALL CLUB CORONAS', 5, 2, 7, 567.34,'RAMON ALLONES-la-fuerza-2.jpg'),
(26,'RAMON ALLONES SPECIALLY SELECTED', 5, 1, 8, 45.63,'RAMON ALLONES-la-fuerza-1.jpg'),
(27,'QUINTERO-BREVAS NO. 54', 7, 1, 9, 34.65,'QUINTERO-BREVAS-signature-no.2-tubos-stick.jpg.png'),
(28,'CUABA BARIAY BOOK 2012', 10, 2, 10, 64.12,'CUABA-coloniales_1_1_2_1_1_1_4_1_1_1_1_1_1_1_1_2_4_1_9.jpg'),
(29,'CUABA SALOMONES', 10, 3, 21, 34.34,'CUABA-no.-2-reserva--cosecha-2010-stick.jpg'),
(30,'DIPLOMATICOS NORTENOS 2018 CANADA REGIONAL EDITION', 11, 4, 22, 4567.12,'DIPLOMATICOS-l-piedra-brevas_1_1_1_9.jpg'),
(31,'EL-REY-DEL-MUNDO DEMI TASSE', 12, 5, 23, 11.45,'EL-REY-DEL-MUNDO-magnum-50_6_4_1_9.jpg'),
(32,'FONSECA NO. 1', 13, 3, 24, 76.34,'FONSECA-50_6_4_1_9.jpg'),
(33,'QUAI-DORSAY NO. 54', 1, 4, 25, 234.76,'QUAI-DORSAY-no.2-stick-new-band.jpg'),
(34,'JOSE-L.-PIEDRA BREVAS', 16, 4, 23, 34.45,'JOSE-L.-PIEDRA BREVAS-open-junior_1_1_2_1_1__1_9.jpg'),
(35,'JOSE-L.-PIEDRA CAZADORES', 16, 1, 23, 25.45,'JOSE-L.-PIEDRA CAZADORES-bariay-book-2012_29_1_1_10.jpg'),
(36,'JUAN-LOPEZ SELECCION NO. 2', 17, 4, 19, 115.45,'UAN-LOPEZ-bariay-book-2012_29_1_1_10.jpg'),
(37,'MONTECRISTO SUPREMOS EDICION LIMITADA 2019', 18, 5, 15, 535.45,'MONTECRISTO-bariay-book-2012_29_1_1_10.jpg'),
(38,'MONTECRISTO OPEN JUNIOR', 18, 3, 17, 545.45,'MONTECRISTO-bariay-book-2012_29_1_1_10.jpg'),
(39,'MONTECRISTO OPEN MASTER TUBOS', 18, 2, 27, 555.45,'TUBOS-bariay-book-2012_29_1_1_10.jpg')

SET IDENTITY_INSERT Cigars OFF

-- Table: Addresses
SET IDENTITY_INSERT Addresses ON

INSERT INTO Addresses (Id, Town, Country, Streat, ZIP) VALUES
(1,'Istanbul','Turkey','13 Martin''s Court','13760'),
(2,'Andorra la Vella','Andorra','21 Alwyns Lane','08043'),
(3,'Tokio','Japan','35 Washpit Drove','06511'),
(4,'Caracas','Venezuela','44 Southgate Mill','117M57'),
(5,'Belgrade','Serbia','55 Holywell Gutter Lane','33G569'),
(6,'Harare', 'Zimbabwe','10 Seaton Cottages','02895-HM'),
(7,'Phnom Penh','Cambodia','5 Evesham Celyn','50401-GA'),
(8,'Praia','Cape Verde','8 Blackbird Glade','23BA860'),
(9,'Bangkok','Thailand','15 Seaton Ridings','97402-NA'),
(10,'San José','Costa Rika','55 Peregrine Heath','174PO02'),
(11,'Dhaka','Bangladesh','33 Holywell Gutter Lane','48042-NB'),
(12,'Quito','Ecuador','1 Arnhall Crescent','28645-QA'),
(13,'Rome','Italy','33 Ashfield Celyn','19002-IU'),
(14,'Yerevan','Armenia','54 Andrews Strand','07501-TA'),
(15,'Kiev' ,'Ukraine','2 Canberra Point','06082-LK'),
(16,'Brasilia','Brazil','98 Stubbin Wood Lane','117AS25'),
(17,'Seoul','South Korea','96 Nottage Meadows','35FD05'),
(18,'Tirana','Albania','22 Lynn Poplars','3212DP7'),
(19,'Warsaw','Poland','36 Gregory Bridge','5508NB2'),
(20,'Stockholm','Sweden','3 Mead Garth','301JK34')


SET IDENTITY_INSERT Addresses OFF

-- Table: Clietns
SET IDENTITY_INSERT Clients ON

INSERT INTO Clients (Id, FirstName, LastName, Email, AddressId) VALUES
(1,'Betty','Wallace','5ornob.Wallace@gmail.com',1),
(2,'Rachel','Bishop','ob.Bishop@gmail.com',2),
(3,'Joan','Peters','5or.Rachel@gmail.com',3),
(4,'Jean','Pierce','oob.Pierce@gmail.com',4),
(5,'Irene','Peters','nob.Peters@gmail.com',5),
(6,'Carol','Miller','nob.Miller@gmail.com',6),
(7,'Jason','Hamilton','nob.Jason@gmail.com',7),
(8,'Brenda','Wallace','Wallace.khan@gmail.com',8),
(9,'Theresa','Riley','5ornob.Riley@gmail.com',9),
(10,'Harry','Jones','5ornob.Jones@gmail.com',10),
(11,'Jerry','Andrews','Jerry@gmail.com',11),
(12,'Jennifer','Cunningham','Jennifer@gmail.com',12),
(13,'Antonio','Lynch','Antonio@gmail.com',13),
(14,'Lisa','Green','hvbob@gmail.com',14),
(15,'Randy','Ramirez','Randy@gmail.com',15),
(16,'Marie','Hudson','Marie.khan@gmail.com',16),
(17,'Rachel','Hill','lhgrnob.khan@gmail.com',17),
(18,'Edward','Mills','rnkob.khan@gmail.com',18),
(19,'Paul','Bishop','5ornob@gmail.com',19),
(20,'Robin','Mitchell','.khan@gmail.com',20)

SET IDENTITY_INSERT Clients OFF

-- Table: ClientsCigars
INSERT INTO ClientsCigars (ClientId, CigarId) VALUES
(1,35),
(2,34),
(3,33),
(4,32),
(5,31),
(6,30),
(9,27),
(11,25),
(12,24),
(13,23),
(14,22),
(15,21),
(16,20),
(17,19),
(18,18),
(19,17),
(20,16),
(1,15),
(2,14),
(2,13),
(3,12),
(4,11),
(5,10),
(6,9),
(9,6),
(11,4),
(12,3),
(13,2),
(14,1),
(15,30),
(16,29),
(17,28),
(18,27),
(19,26),
(20,25),
(3,24),
(19,21),
(20,20),
(14,19),
(11,17),
(15,16),
(11,38),
(12,35),
(12,39),
(12,38),
(13,34),
(14,33),
(15,34),
(16,33),
(17,35),
(1,36),
(11,36),
(1,39),
(1,38),
(2,39),
(2,38),
(2,37),
(2,36)