INSERT INTO [dbo].[Locations] (LocationName)
	VALUES
	('Sun'), ('Mercury'), ('Venus'), ('Earth'), ('Mars'),
	('Jupiter'), ('Saturn'), ('Uranus'), ('Neptune');

INSERT INTO [dbo].[Distances] (DistanceMiles)
	VALUES
	(35983015), (67237910), (92955807), (141670000), (481773286), (890704144), (1783939400), (2795084800),
	(31248757),	(56974146),	(105651744), (447648234), (849221795), (1749638696), (2760936126), 
	(25724767), (74402987), (416399477), (817973037), (1718388490), (2729685920), 
	(48678219), (390674710), (792248270), (1692662530), (2703959960),
	(342012346), (743604524), (1643982054), (2313267138),
	(401592178), (1301969708), (2313267138),
	(900377530), (1911674960), 
	(1011297430);

INSERT INTO [dbo].[LocationDistance] (LocationOneId, LocationTwoId, DistanceId)
	VALUES
	(1, 2, 1), (2, 1, 1), --Sun / Mercury
	(1, 3, 2), (3, 1, 2), --Sun / Venus
	(1, 4, 3), (4, 1, 3), --Sun / Earth
	(1, 5, 4), (5, 1, 4), --Sun / Mars
	(1, 6, 5), (6, 1, 5), --Sun / Jupiter
	(1, 7, 6), (7, 1, 6), --Sun / Saturn
	(1, 8, 7), (8, 1, 7), --Sun / Uranus
	(1, 9, 8), (9, 1, 8), --Sun / Neptune
	(2, 3, 9), (3, 2, 9), --Mercury / Venus
	(2, 4, 10), (4, 2, 10),  --Mercury / Earth
	(2, 5, 11), (5, 2, 11), --Mercury / Mars
	(2, 6, 12), (6, 2, 12), --Mercury / Jupiter
	(2, 7, 13), (7, 2, 13), --Mercury / Saturn
	(2, 8, 14), (8, 2, 14), --Mercury / Uranus
	(2, 9, 15), (9, 2, 15), --Mercury / neptune
	(3, 4, 16), (4, 3, 16), --Venus / Earth
	(3, 5, 17), (5, 3, 17), --Venus / Mars
	(3, 6, 18), (6, 3, 18), --Venus / Jupiter
	(3, 7, 19), (7, 3, 19), --Venus / Saturn
	(3, 8, 20), (8, 3, 20), --Venus / Uranus
	(3, 9, 21), (9, 3, 21), --Venus / Neptune
	(4, 5, 22), (5, 4, 22), --Earth / Mars
	(4, 6, 23), (6, 4, 23), --Earth / Jupiter
	(4, 7, 24), (7, 4, 24), --Earth / Saturn
	(4, 8, 25), (8, 4, 25), --Earth / Uranus
	(4, 9, 26), (9, 4, 26), --Earth / Neptune
	(5, 6, 27), (6, 5, 27), --Mars / Jupiter
	(5, 7, 28), (7, 5, 28), --Mars / Saturn
	(5, 8, 29), (8, 5, 29), --Mars / Uranus
	(5, 9, 30), (9, 5, 30), --Mars / Neptune
	(6, 7, 31), (7, 6, 31), --Jupiter / Saturn
	(6, 8, 32), (8, 6, 32), --Jupiter / Uranus
	(6, 9, 33), (9, 6, 33), --Jupiter / Neptune
	(7, 8, 34), (8, 7, 34), --Saturn / Uranus
	(7, 9, 35), (9, 7, 35), --Saturn / Neptune
	(8, 9, 36), (9, 8, 36); --Uranus / Neptune
