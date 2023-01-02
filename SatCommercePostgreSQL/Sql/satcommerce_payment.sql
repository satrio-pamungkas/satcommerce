--
-- PostgreSQL database dump
--

-- Dumped from database version 12.12 (Ubuntu 12.12-0ubuntu0.20.04.1)
-- Dumped by pg_dump version 14.5 (Ubuntu 14.5-0ubuntu0.22.04.1)

DROP DATABASE IF EXISTS satcommerce_payment;
CREATE DATABASE satcommerce_payment;
\c satcommerce_payment;

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
-- Name: Payments; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Payments" (
    "Id" uuid NOT NULL,
    "IdNumber" text NOT NULL,
    "ImageUrl" text,
    "Name" text,
    "Type" text
);


ALTER TABLE public."Payments" OWNER TO postgres;

--
-- Data for Name: Payments; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Payments" ("Id", "IdNumber", "ImageUrl", "Name", "Type") VALUES ('25790418-0c7f-48ce-b7b8-295d7485cc49', '100500201', 'https://raw.githubusercontent.com/mpay24/payment-logos/master/logos%402x/color/mastercard%402x.png', 'Master Card', 'Credit Card');
INSERT INTO public."Payments" ("Id", "IdNumber", "ImageUrl", "Name", "Type") VALUES ('4de84d09-c27e-4a18-8943-5443d9284076', '32222223', 'https://raw.githubusercontent.com/mpay24/payment-logos/master/logos%402x/color/wechat_pay%402x.png', 'Wechat Pay', 'Wallets');
INSERT INTO public."Payments" ("Id", "IdNumber", "ImageUrl", "Name", "Type") VALUES ('610d3935-04ee-4726-9a8b-139ba495073f', '32323233', 'https://raw.githubusercontent.com/mpay24/payment-logos/master/logos%402x/color/maestro%402x.png', 'Maestro', 'Online Banking');
INSERT INTO public."Payments" ("Id", "IdNumber", "ImageUrl", "Name", "Type") VALUES ('a048c923-f07d-43f4-ade5-20487d04594b', '2232222', 'https://raw.githubusercontent.com/mpay24/payment-logos/master/logos%402x/color/paypal%402x.png', 'Paypal', 'Online Banking');
INSERT INTO public."Payments" ("Id", "IdNumber", "ImageUrl", "Name", "Type") VALUES ('bc365c48-47a8-4ddb-a37e-5210e6ef8918', '3223333', 'https://raw.githubusercontent.com/mpay24/payment-logos/master/logos%402x/color/alipay%402x.png', 'Alipay', 'Wallets');
INSERT INTO public."Payments" ("Id", "IdNumber", "ImageUrl", "Name", "Type") VALUES ('e483ae45-fca0-4892-8595-bddddf99508f', '23100423232', 'https://raw.githubusercontent.com/mpay24/payment-logos/master/logos%402x/color/visa%402x.png', 'Visa', 'Credit Card');


--
-- Name: Payments Payments_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Payments"
    ADD CONSTRAINT "Payments_pkey" PRIMARY KEY ("IdNumber");


--
-- Name: TABLE "Payments"; Type: ACL; Schema: public; Owner: postgres
--


--
-- Name: DEFAULT PRIVILEGES FOR TABLES; Type: DEFAULT ACL; Schema: -; Owner: postgres
--


--
-- PostgreSQL database dump complete
--

