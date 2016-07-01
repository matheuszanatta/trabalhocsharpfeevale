ALTER TABLE Medicos
ADD Ativo bit,
 IDUsuario bigint
 FOREIGN KEY (IDUsuario) REFERENCES Usuarios(IDUsuario)

ALTER TABLE Pessoas
ADD Ativo bit

