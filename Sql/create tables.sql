CREATE TABLE product (
	id serial PRIMARY KEY,
	name VARCHAR(64) NOT NULL
);

CREATE TABLE category (
	id serial PRIMARY KEY,
	name VARCHAR(64) NOT NULL
);

CREATE TABLE product_category(
	id serial PRIMARY KEY,
	product_id int REFERENCES product(id),
	category_id int REFERENCES category(id)
);

