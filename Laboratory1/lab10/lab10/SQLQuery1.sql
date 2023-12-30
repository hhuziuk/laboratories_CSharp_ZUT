drop table invoice_pos
go
drop table invoice
go
create table invoice(
invoice_id numeric identity not null,
number varchar(20) not null,
value decimal,
constraint pk_invoice primary key (invoice_id)
)
go
create table invoice_pos(
invoice_pos_id numeric identity not null,
invoice_id numeric not null,
name varchar(20) not null,
value decimal,
constraint pk_invoice_pos primary key (invoice_pos_id),
constraint fk_invoice_pos foreign key (invoice_id) references invoice(invoice_id)
)
go
select * from invoice
select * from invoice_pos