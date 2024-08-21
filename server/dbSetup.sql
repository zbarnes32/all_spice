CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) UNIQUE COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';


CREATE TABLE recipes(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  title VARCHAR(255) NOT NULL,
  instructions VARCHAR(5000) NOT NULL,
  img VARCHAR(1000) NOT NULL,
  category ENUM('breakfast', 'lunch', 'dinner', 'snack', 'dessert') NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
);

SELECT 
  recipes.*,
  accounts.*
FROM
  recipes
  JOIN accounts ON accounts.id = recipes.creatorId
  WHERE
    recipes.id = 1
