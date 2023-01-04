--
-- PostgreSQL database dump
--

-- Dumped from database version 12.12 (Ubuntu 12.12-0ubuntu0.20.04.1)
-- Dumped by pg_dump version 14.5 (Ubuntu 14.5-0ubuntu0.22.04.1)

DROP DATABASE IF EXISTS satcommerce_product;
CREATE DATABASE satcommerce_product;
\c satcommerce_product;

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Products; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Products" (
    "Id" uuid NOT NULL,
    "Name" text,
    "Description" text,
    "ImageUrl" text,
    "Brand" text,
    "Slug" text,
    "Weight" integer,
    "Sold" integer,
    "Rating" integer,
    "Price" integer,
    "Quantity" integer
);


ALTER TABLE public."Products" OWNER TO root;

--
-- Data for Name: Products; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Products" ("Id", "Name", "Description", "ImageUrl", "Brand", "Slug", "Weight", "Sold", "Rating", "Price", "Quantity") VALUES ('10b74863-5d93-4e3b-9e36-d10ba65ddddb', 'Gray Suitcase', 'AmazonBasics - Maleta de mano ligera para cabina, color gris oscuro', 'https://m.media-amazon.com/images/I/81fx0Z6ByML.jpg', 'Amazon Basics', 'gray-suitcase-10b74863-5d93-4e3b-9e36-d10ba65ddddb', 3000, 4, 4, 1320000, 54);
INSERT INTO public."Products" ("Id", "Name", "Description", "ImageUrl", "Brand", "Slug", "Weight", "Sold", "Rating", "Price", "Quantity") VALUES ('15170cd6-eac7-4361-b986-d6dd6c2e0843', 'Cilantaro Rice', 'Cilantro Rice with Black Beans, 12 oz', 'https://m.media-amazon.com/images/I/71xKy3c17NL.jpg', 'Amazon Kitchen', 'cilantaro-rice-15170cd6-eac7-4361-b986-d6dd6c2e0843', 350, 13, 4, 32000, 1432);
INSERT INTO public."Products" ("Id", "Name", "Description", "ImageUrl", "Brand", "Slug", "Weight", "Sold", "Rating", "Price", "Quantity") VALUES ('1952966a-5ef3-4c51-839c-2cc518352cc3', 'USB Wall Charger', 'Amazon Basics One-Port USB Wall Charger (2.4 Amp) - White (EU version)', 'https://m.media-amazon.com/images/I/61VXRGS-NKL.jpg', 'Amazon Basics', 'usb-wall-charger-1952966a-5ef3-4c51-839c-2cc518352cc3', 200, 32, 4, 56000, 423);
INSERT INTO public."Products" ("Id", "Name", "Description", "ImageUrl", "Brand", "Slug", "Weight", "Sold", "Rating", "Price", "Quantity") VALUES ('1fed1c91-bc6d-4a65-9bbd-dc12f7fe011a', 'White Casual Sneaker', 'Concept 3 by Skechers Issel Lace-up Casual Sneaker', 'https://m.media-amazon.com/images/I/81svzHPcn7L.jpg', 'Skechers', 'white-casual-sneaker-1fed1c91-bc6d-4a65-9bbd-dc12f7fe011a', 500, 12, 4, 250000, 132);
INSERT INTO public."Products" ("Id", "Name", "Description", "ImageUrl", "Brand", "Slug", "Weight", "Sold", "Rating", "Price", "Quantity") VALUES ('32fcf410-cd80-4551-beeb-d3959fdf64f4', 'Fabric Chair', 'Stone & Beam Clayton Modern Clayton Living Room Chair Fabric', 'https://m.media-amazon.com/images/I/81CicEeqFoL.jpg', 'Stone & Beam', 'fabric-chair-32fcf410-cd80-4551-beeb-d3959fdf64f4', 3600, 16, 4, 1500000, 42);
INSERT INTO public."Products" ("Id", "Name", "Description", "ImageUrl", "Brand", "Slug", "Weight", "Sold", "Rating", "Price", "Quantity") VALUES ('41ea683c-25da-46fe-9da5-9b9072997b24', 'Citrus & Lavender Disinfectan', 'Amazon Brand - Presto! Disinfectant Surface Cleaner, Pack of 2 - 975 ml (Citrus & Lavender)', 'https://m.media-amazon.com/images/I/71VL-NwnK8L.jpg', 'Presto', 'citrus-lavender-disinfectan-41ea683c-25da-46fe-9da5-9b9072997b24', 1200, 32, 4, 135000, 54);
INSERT INTO public."Products" ("Id", "Name", "Description", "ImageUrl", "Brand", "Slug", "Weight", "Sold", "Rating", "Price", "Quantity") VALUES ('5e05a25b-d789-4d5e-9ed0-a6788f1a6bf3', 'Digital Tire Pressure Gauge', 'Amazon Basics Digital Tire Pressure Gauge - Red, 3-Pack', 'https://m.media-amazon.com/images/I/71V57qnwguL.jpg', 'Amazon Basics', 'digital-tire-pressure-gauge-5e05a25b-d789-4d5e-9ed0-a6788f1a6bf3', 500, 52, 5, 250000, 242);
INSERT INTO public."Products" ("Id", "Name", "Description", "ImageUrl", "Brand", "Slug", "Weight", "Sold", "Rating", "Price", "Quantity") VALUES ('5fb9e4c0-2cf9-4a18-bcfb-59bc70ed9569', 'Multi-Purpose Cleaner', 'Amazon Commercial Multi-Purpose Peroxide Cleaner, Concentrate, 1-Gallon, 1-Pack', 'https://m.media-amazon.com/images/I/51l+engr3RL.jpg', 'Amazon', 'multi-purpose-cleaner-5fb9e4c0-2cf9-4a18-bcfb-59bc70ed9569', 3500, 4, 3, 250000, 32);
INSERT INTO public."Products" ("Id", "Name", "Description", "ImageUrl", "Brand", "Slug", "Weight", "Sold", "Rating", "Price", "Quantity") VALUES ('5ff61020-9c10-48c6-8c1d-b19d6bdf8234', 'Pet Carrier', 'Amazon Basics Pet Carrier Kennel With Metal Wire Ventilation,23-Inch', 'https://m.media-amazon.com/images/I/813D6acTpRL.jpg', 'Amazon', 'pet-carrier-5ff61020-9c10-48c6-8c1d-b19d6bdf8234', 1000, 3, 3, 370000, 32);
INSERT INTO public."Products" ("Id", "Name", "Description", "ImageUrl", "Brand", "Slug", "Weight", "Sold", "Rating", "Price", "Quantity") VALUES ('67e91eeb-537d-4f9a-895d-68225d6c28c5', 'Cream Style Corn', 'Amazon Brand - Happy Belly Cream Style Corn, 15 Ounce', 'https://m.media-amazon.com/images/I/71TR1oboZbL.jpg', 'Amazon', 'cream-style-corn-67e91eeb-537d-4f9a-895d-68225d6c28c5', 425, 23, 4, 50000, 213);
INSERT INTO public."Products" ("Id", "Name", "Description", "ImageUrl", "Brand", "Slug", "Weight", "Sold", "Rating", "Price", "Quantity") VALUES ('8741ea6b-f4a9-450d-9437-2b430484f59f', 'Blend & Go Smoothie Blender', 'Amazon Basics Blend & Go Smoothie Blender, 600 ml, 600 W 600 ml, 600 W zwart', 'https://m.media-amazon.com/images/I/71f-hmopL8L.jpg', 'Amazon Basics', 'blend-go-smoothie-blender-8741ea6b-f4a9-450d-9437-2b430484f59f', 1000, 23, 5, 450000, 32);
INSERT INTO public."Products" ("Id", "Name", "Description", "ImageUrl", "Brand", "Slug", "Weight", "Sold", "Rating", "Price", "Quantity") VALUES ('a1e689bf-3848-4b5b-baa4-d4116f922860', 'Pet Food', 'Amazon Brand – Wag Dry Dog Food, Salmon and Brown Rice, 5 lb Bag', 'https://m.media-amazon.com/images/I/71AvEqe4msL.jpg', 'Amazon', 'pet-food-a1e689bf-3848-4b5b-baa4-d4116f922860', 2500, 21, 4, 50000, 1200);
INSERT INTO public."Products" ("Id", "Name", "Description", "ImageUrl", "Brand", "Slug", "Weight", "Sold", "Rating", "Price", "Quantity") VALUES ('a22e8fde-484f-47ff-8a9e-c68cb338e521', 'Stainless Steel Frying Pan', 'Amazon Commercial 30 cm Stainless Steel Aluminium-Clad Frying Pan with Helper Handle', 'https://m.media-amazon.com/images/I/71cs-lQf6OL.jpg', 'Amazon', 'stainless-steel-frying-pan-a22e8fde-484f-47ff-8a9e-c68cb338e521', 600, 14, 4, 175000, 46);
INSERT INTO public."Products" ("Id", "Name", "Description", "ImageUrl", "Brand", "Slug", "Weight", "Sold", "Rating", "Price", "Quantity") VALUES ('a72176f4-f267-46ba-9092-8c5c69ff8bb8', 'Pail & Mop Bucket', 'Amazon Commercial Pail and Mop Strainer Combo With Dirt Filter, 17-Quart, Yellow - 3-Pack', 'https://m.media-amazon.com/images/I/71iWruBxYVL.jpg', 'Amazon', 'pail-mop-bucket-a72176f4-f267-46ba-9092-8c5c69ff8bb8', 300, 23, 5, 75000, 124);
INSERT INTO public."Products" ("Id", "Name", "Description", "ImageUrl", "Brand", "Slug", "Weight", "Sold", "Rating", "Price", "Quantity") VALUES ('b25ec246-1572-4b81-92c8-1987af456594', 'Thermoplastic Filament', 'Amazon Basics PLA 3D Printer Filament, 1.75mm, Neon Green, 1 kg Spool', 'https://m.media-amazon.com/images/I/91q3DDlqKNL.jpg', 'Amazon Basics', 'thermoplastic-filament-b25ec246-1572-4b81-92c8-1987af456594', 1000, 12, 4, 100000, 32);
INSERT INTO public."Products" ("Id", "Name", "Description", "ImageUrl", "Brand", "Slug", "Weight", "Sold", "Rating", "Price", "Quantity") VALUES ('b314c5cd-437b-4cc0-b5fd-188c841502aa', 'Composition Notebook 4-Pack', 'Amazon Basics Wide Ruled Composition Notebook, 100-Sheet, Assorted Solid Colors, 4-Pack', 'https://m.media-amazon.com/images/I/71FBwRSRcTL.jpg', 'Amazon Basics', 'composition-notebook-4-pack-b314c5cd-437b-4cc0-b5fd-188c841502aa', 1600, 52, 5, 120000, 52);
INSERT INTO public."Products" ("Id", "Name", "Description", "ImageUrl", "Brand", "Slug", "Weight", "Sold", "Rating", "Price", "Quantity") VALUES ('d2da5136-a979-439d-9fed-a2495f42a4ef', 'Backpack', 'Amazon Basics – Mochila para cámara DSLR (poliéster 840D de Alta Densidad, Resistente al Agua) – Gris Ceniza', 'https://m.media-amazon.com/images/I/A1SjdZpIg2L.jpg', 'Amazon Basics', 'backpack-d2da5136-a979-439d-9fed-a2495f42a4ef', 500, 24, 4, 350000, 52);
INSERT INTO public."Products" ("Id", "Name", "Description", "ImageUrl", "Brand", "Slug", "Weight", "Sold", "Rating", "Price", "Quantity") VALUES ('d6944d09-6e5a-4f66-8967-db89698f05a1', 'Amazon Cap Gear', 'Amazon Gear Pro Wool Flex Fit Hat, Black, X-Small/Small', 'https://m.media-amazon.com/images/I/91Wweqjop7L.jpg', 'Amazon', 'amazon-cap-gear-d6944d09-6e5a-4f66-8967-db89698f05a1', 200, 32, 4, 75000, 123);
INSERT INTO public."Products" ("Id", "Name", "Description", "ImageUrl", "Brand", "Slug", "Weight", "Sold", "Rating", "Price", "Quantity") VALUES ('e8c93f0c-59d5-4d7c-9ed5-bc4665367345', 'Blue Gaming Chair', 'UMI. Essentials - Sedia ergonomica da Gioco, con poggiapiedi Imbottito, Colore: Blu', 'https://m.media-amazon.com/images/I/415Ps5mQf+L.jpg', 'UMI', 'blue-gaming-chair-e8c93f0c-59d5-4d7c-9ed5-bc4665367345', 3000, 3, 4, 1450000, 21);
INSERT INTO public."Products" ("Id", "Name", "Description", "ImageUrl", "Brand", "Slug", "Weight", "Sold", "Rating", "Price", "Quantity") VALUES ('fb4ad848-ad00-4bde-911a-10965115c795', 'Digital Multimeter', 'Amazon Commercial Commercial 2000 Count Manual Ranging Digital Multimeter', 'https://m.media-amazon.com/images/I/81D8y9r4jHL.jpg', 'Amazon', 'digital-multimeter-fb4ad848-ad00-4bde-911a-10965115c795', 340, 8, 4, 50000, 46);


--
-- Name: Products Products_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "Products_pkey" PRIMARY KEY ("Id");


--
-- Name: TABLE "Products"; Type: ACL; Schema: public; Owner: postgres
--


--
-- Name: DEFAULT PRIVILEGES FOR TABLES; Type: DEFAULT ACL; Schema: -; Owner: postgres
--


--
-- PostgreSQL database dump complete
--

