import random
import math
import json


def generate_dummy_network(node_count, directed=False):
    nodes = [0] * node_count
    for i in range(node_count):
        edge_count = random.randint(0, int(math.log2(node_count)))
        edges = []
        while edge_count > 0:
            edge = random.randint(0, node_count)
            if edge not in edges:
                # edge > i is to ensure a directed graph is specified.
                # if the random number is greater than i edges will always flow one way
                if not directed or edge > i:
                    edges.append(edge)
                    edge_count -= 1
        nodes[i] = edges
    return nodes


def network_to_json(nodes):
    return json.dumps(nodes, indent=1)


n = generate_dummy_network(10)
print(n)
#print(network_to_json(n))
