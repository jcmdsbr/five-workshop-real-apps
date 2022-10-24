# Integração do Banco do Morangão 2.0

Estamos construindo um aplicativo para interagir com o antigo banco do morangão, para isso iremos precisar de um conjunto de APIs HTTP para integração.
Porém o banco do Morangão atual não foi construído para isso, por isso iremos realizar a modernização dele para que ele se torne escalável.

## Funcionalidades

- Cadastro/Alteração de Clientes e suas Contas.
- Permitir saque em conta desde que haja saldo.
- Permitir deposito em conta desde ela esteja disponível.
- Consultar saldo em conta desde ela esteja disponível, caso contrário informar inatividade.

## Especificações

O sistema deve permitir o cadastro de novos clientes, através de informações básicas como nome, cpf, data de nascimento e endereço.
O endereço deve ser validado através do serviço externo VIACEP e caso não exista o cadastro precisa ser invalidado.
O cliente precisa ser maior de idade para se cadastrar
Deve ser criado uma conta de maneira automática após o cadastramento do cliente, o saldo mínimo para abertura em conta é de R$ 100,00.
Só deve ser permitido CPF válido para o cadastro e ele deve ser único.

