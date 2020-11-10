-- drop table orders;
-- drop table inventory;
-- drop table product;
-- drop table manager;
-- drop table location;
-- drop table customer;

-- creating the customer table --
create table customer
(
	id serial primary key,
	name varchar(100) not null,
    password varchar(200) not null,
	address varchar(200) not null
);

-- creating the location table --
create table location
(
	id serial primary key,
	state varchar(100) not null,
	city varchar(200) not null,
    street varchar(200) not null
);

-- creating the manager table --
create table manager
(
	id serial primary key,
	name varchar(100) not null,
    password varchar(200) not null,
	locationid int references location (id)
);

-- creating the product table --
create table product
(
	id serial primary key,
	gamename varchar(200) not null,
	price int not null
);

-- creating the order table --
create table orders
(
	id serial primary key,
	date timestamp not null,
	cost int not null,
	customerid int references customer (id),
	locationid int references location (id)
);

-- creating the inventory table --
create table inventory
(
	id serial primary key,
	quantity int not null,
	productid int references product (id),
	locationid int references location (id)

);

-- creating orderitems table --
create table orderitems
(
	id serial primary key,
	totalitems int not null,
	productid int references product (id),
	orderid int references orders (id)
);

-- inserting seed data --
insert into customer (name, password, address) values
('John Barr', '12345', '301 NY'),
('Larry King', 'apassword', '750 CA');


insert into location (state, city, street) values
('NY', 'Syracuse', 'E Jefferson St'),
('CA', 'Los Angeles','W 35th St');

insert into manager (name, password, locationid) values
('John Barr', '12345', 1),
('Larry King', 'apassword', 2);

insert into product (gamename, price) values
('Spyro', 35),
('Cyberpunk 2077', 60);


insert into inventory (quantity, productid, locationid) values
(20, 1, 1),
(65, 2, 1),
(10, 1, 2);
(80, 2, 2);