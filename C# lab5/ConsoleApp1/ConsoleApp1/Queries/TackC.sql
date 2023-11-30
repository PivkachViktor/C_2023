SELECT * FROM Employees 
WHERE Department = 'IT' 
    AND (RoomNumber BETWEEN 101 AND 105 OR LastName LIKE 'S%');
