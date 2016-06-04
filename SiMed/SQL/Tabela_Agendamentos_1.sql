CREATE TABLE Agendamentos(
	IdAgendamento INT IDENTITY,
	IDMedico BIGINT,
	CPFPessoa VARCHAR(50),
	DhAgendamento DATETIME,
	Situacao BIT

	FOREIGN KEY (IDMedico) REFERENCES Medicos(IDMedico),
	FOREIGN KEY (CPFPessoa) REFERENCES Pessoas(CPF)
)