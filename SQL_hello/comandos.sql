/*
UPDATE Produtos set descricao = 'Caneta Verde' where idProduto = 6
SELECT * FROM Produtos
*/

/*
INSERT INTO Estoque(idProduto,quantidade)
VALUES(2,200),(3,230)
*/
/*
SELECT p.nomeProduto AS 'NOME DO PRODUTO', 
       p.descricao AS 'DESCRIÇÃO', 
       e.quantidade AS 'QUANTIDADE'
FROM Produtos p INNER JOIN Estoque e
ON P.idProduto = e.idProduto
WHERE p.descricao LIKE 'Caneta Vermelha'
*/

SELECT c.nomeCliente AS 'NOME DO CLIENTE',
       p.nomeProduto AS 'NOME DO PRODUTO',
       d.quantidade AS 'QUANTIDADE COMPRADA'
FROM Produtos p INNER JOIN DetalhesPedido d INNER JOIN Pedidos pe INNER JOIN Clientes c
       
 








