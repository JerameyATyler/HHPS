DROP EXTENSION IF EXISTS pgcrypto;

DROP TABLE IF EXISTS disseminations;
DROP TABLE IF EXISTS buy_ins;
DROP TABLE IF EXISTS pot;
DROP TABLE  IF EXISTS edges;
DROP TABLE  IF EXISTS nodes;
DROP TABLE  IF EXISTS  causes;
DROP TRIGGER IF EXISTS insert_user_trigger ON users;
DROP FUNCTION IF EXISTS insert_user_trigger_function();
DROP TABLE IF EXISTS users;

CREATE EXTENSION pgcrypto;

CREATE TABLE users(
  user_id SERIAL NOT NULL PRIMARY KEY,
  first TEXT NOT NULL,
  last TEXT NOT NULL,
  email TEXT NOT NULL,
  password TEXT NOT NULL
);

CREATE FUNCTION insert_user_trigger_function() RETURNS TRIGGER AS
$BODY$
  BEGIN
    INSERT INTO users(first, last, email, password)
    VALUES (new.first, new.last, new.email, crypt(new.password, gen_salt('bf')));
  RETURN new;
END;
$BODY$
LANGUAGE plpgsql;

CREATE TRIGGER insert_user_trigger
  BEFORE INSERT ON users
  FOR EACH ROW
  EXECUTE PROCEDURE insert_user_trigger_function();

CREATE TABLE causes(
  cause_id SERIAL PRIMARY KEY,
  hashtag TEXT NOT NULL,
  cause_TEXT TEXT NOT NULL
);

CREATE TABLE nodes (
  node_id SERIAL NOT NULL PRIMARY KEY,
  user_id SERIAL NOT NULL REFERENCES users(user_id),
  cause_id SERIAL NOT NULL REFERENCES causes(cause_id),
  state INTEGER NOT NULL,
  plays INTEGER NOT NULL,
  UNIQUE (user_id, cause_id)
);

CREATE TABLE edges(
  edge_id SERIAL NOT NULL PRIMARY KEY,
  node_a SERIAL NOT NULL REFERENCES nodes(node_id),
  node_b SERIAL NOT NULL REFERENCES nodes(node_id),
  CHECK (node_a <> node_b)
);

CREATE TABLE pot(
  pot_id SERIAL NOT NULL PRIMARY KEY,
  cause_id SERIAL NOT NULL REFERENCES causes(cause_id),
  pot_total INTEGER NOT NULL,
  next_payout INTEGER NOT NULL,
  winner_id SERIAL REFERENCES users(user_id),
  collected BOOLEAN DEFAULT FALSE
);

CREATE TABLE buy_ins(
  buy_in_id SERIAL NOT NULL PRIMARY KEY,
  user_id SERIAL NOT NULL REFERENCES users(user_id),
  cause_id SERIAL NOT NULL REFERENCES causes(cause_id),
  amount INTEGER NOT NULL ,
  CHECK (amount > 0)
);

CREATE TABLE disseminations(
  dissemination_id SERIAL NOT NULL PRIMARY KEY,
  node_id SERIAL NOT NULL REFERENCES nodes(node_id)
);