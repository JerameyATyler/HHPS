
drop TABLE  IF EXISTS nodes;
create TABLE nodes (
  node UUID NOT NULL,
  cause UUID NOT NULL,
  state INTEGER NOT NULL,
  plays INTEGER NOT NULL,
  PRIMARY KEY (node, cause)
);

drop TABLE  IF EXISTS edges;
create TABLE edges(
  enda UUID NOT NULL,
  endb UUID NOT NULL,
  cause UUID NOT NULL,
  PRIMARY KEY (enda, endb, cause)
);

drop TABLE  IF EXISTS  causes;
create table causes(
  cause UUID NOT NULL,
  hashtag text NOT NULL PRIMARY KEY,
  PRIMARY KEY (cause, hashtag)
);

drop TABLE IF EXISTS users;
create table users(
  node UUID NOT NULL PRIMARY KEY,
  first text NOT NULL,
  last text NOT NULL,
  email text NOT NULL,
  password text NOT NULL,
  salt text NOT NULL
);

drop TABLE IF EXISTS pot;
create TABLE pot(
  cause UUID NOT NULL PRIMARY KEY,
  total INTEGER NOT NULL,
  next_payout INTEGER NOT NULL
);