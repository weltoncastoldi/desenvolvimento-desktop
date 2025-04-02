CREATE DATABASE IF NOT EXISTS multapps_dev;

USE multapps_dev;

CREATE TABLE IF NOT EXISTS categoria (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    data_alteracao TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    status ENUM('inativo', 'ativo', 'excluido') NOT NULL
);

CREATE TABLE IF NOT EXISTS produto (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    categoria_id INT NOT NULL,
    nome VARCHAR(100) NOT NULL,
    preco DECIMAL(10,2) NOT NULL, -- Definição da precisão do decimal
    quantidade_estoque INT NOT NULL,
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    data_alteracao TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    status ENUM('inativo', 'ativo', 'excluido') NOT NULL,
    FOREIGN KEY (categoria_id) REFERENCES categoria(id)
);
