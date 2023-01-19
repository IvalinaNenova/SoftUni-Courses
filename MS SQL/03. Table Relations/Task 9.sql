USE [Geography]

SELECT Mountains.MountainRange, PeakName, Elevation
    FROM Peaks JOIN Mountains ON
	Peaks.MountainId = Mountains.Id
	WHERE Mountains.MountainRange = 'Rila'
	ORDER BY Elevation DESC
