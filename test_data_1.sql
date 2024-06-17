USE `casablanca`;

-- Insert test data into `city`
INSERT INTO `city` (`name`, `post_code`) VALUES
('New York', '10001'),
('Los Angeles', '90001'),
('Chicago', '60601');

-- Insert test data into `address`
INSERT INTO `address` (`name`, `number`, `city_id`) VALUES
('Main St', 123, 1),
('Broadway', 456, 2),
('Michigan Ave', 789, 3);

-- Insert test data into `user`
INSERT INTO `user` (`username`, `password`, `first_name`, `last_name`, `theme`, `language`, `salary`, `is_admin`) VALUES
('jdoe', 'password1', 'John', 'Doe', 'dark', 'English', 50000, 1),
('asmith', 'password2', 'Alice', 'Smith', 'light', 'English', 40000, 0);

-- Insert test data into `article type`
INSERT INTO `article type` (`type_name`) VALUES
('Book'),
('Magazine'),
('DVD');

-- Insert test data into `supplier`
INSERT INTO `supplier` (`name`, `contact`) VALUES
('Supplier1', 'contact1'),
('Supplier2', 'contact2');

-- Insert test data into `invoice`
INSERT INTO `invoice` (`price`, `date`, `user_id`, `supplier_id`) VALUES
(100.50, '2023-01-01 10:00:00', 1, 1),
(200.75, '2023-02-01 11:00:00', 2, 2);

-- Insert test data into `publisher`
INSERT INTO `publisher` (`id`, `name`) VALUES
(1, 'Publisher1'),
(2, 'Publisher2');

-- Insert test data into `article`
INSERT INTO `article` (`id`, `name`, `image`, `type_id`, `is_rented`, `price`, `publisher_id`, `invoice_id`, `is_for_sale`) VALUES
(1, 'Article1', 'image1.jpg', 1, 0, 10.00, 1, 1, 1),
(2, 'Article2', 'image2.jpg', 2, 1, 20.00, 2, 2, 0);

-- Insert test data into `customer`
INSERT INTO `customer` (`first_name`, `last_name`, `JMB`, `address_id`, `phone_number`) VALUES
('Michael', 'Johnson', '1234567890123', 1, '555-1234'),
('Sara', 'Connor', '9876543210987', 2, '555-5678');

-- Insert test data into `rental`
INSERT INTO `rental` (`rent_date`, `due_date`, `return_date`, `price`, `cutomer_id`) VALUES
('2023-03-01 09:00:00', '2023-03-10 09:00:00', NULL, 5.00, 1),
('2023-04-01 10:00:00', '2023-04-15 10:00:00', '2023-04-14 09:00:00', 7.50, 2);

-- Insert test data into `rented article`
INSERT INTO `rented article` (`article_id`, `rental_id`, `price`) VALUES
(1, 1, 5.00),
(2, 2, 7.50);
