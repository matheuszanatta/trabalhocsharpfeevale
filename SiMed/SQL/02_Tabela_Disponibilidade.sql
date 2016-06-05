CREATE TABLE Disponibilidades(
	IDDisponibilidade BIGINT IDENTITY NOT NULL,
	IDMedico BIGINT NOT NULL,
	Dia DATE NOT NULL,
	InicioTurno1 TIME NULL,
	FimTurno1 TIME NULL ,
	InicioTurno2 TIME NULL,
	FimTurno2 TIME NULL

	FOREIGN KEY (IDMedico) REFERENCES Medicos(IDMedico)
)

ALTER TABLE Disponibilidades
ADD CONSTRAINT UK_IDMedico_Dia UNIQUE (IDMedico, Dia)