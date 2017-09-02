
drop TABLE  IF EXISTS nodes;
create TABLE nodes (
  node UUID NOT NULL,
  cause UUID NOT NULL,
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
  hashtag text NOT NULL PRIMARY KEY
);

