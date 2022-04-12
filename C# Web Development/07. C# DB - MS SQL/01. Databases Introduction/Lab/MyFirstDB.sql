DECLARE @CharVar CHAR(5) = 'Test';
DECLARE @VarcharVar VARCHAR(5) = 'Test';
DECLARE @NCharVar NCHAR(5) = 'Test';
DECLARE @NVarcharVar NVARCHAR(5) = 'Test';

SELECT DATALENGTH(@CharVar),
       DATALENGTH(@VarcharVar),
       DATALENGTH(@NCharVar),
       DATALENGTH(@NVarcharVar)
