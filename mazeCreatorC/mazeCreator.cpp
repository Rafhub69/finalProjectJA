#include "pch.h"
#include "mazeCreator.h"

cell::cell()
{
	topWall = true;
	leftWall = true;
	rightWall = true;
	bottomWall = true;
}

labiryntCreator::labiryntCreator(int newHeight, int newWidth)
{
	
	for (int i = 0; i < newHeight; i++)
	{
		std::vector<cell> v;
		cell c;

		for (int j = 0; j < newHeight; j++)
		{
			v.push_back(c);
		}

		maze.push_back(v);
	}

	maze.at(currentCellx).at(currentCelly).visited = true;
	cell neightbour = checkNeightbours(currentCellx, currentCelly);

	if (neightbour != nullptr)
	{
		neightbour.visited = true;

	}
}

cell labiryntCreator::checkNeightbours(int cellX, int cellY)
{
	srand((unsigned)time(NULL));

	std::vector< cell> neightbours;

	cell top = maze.at(cellX).at(cellY - 1);
	cell right = maze.at(cellX  + 1).at(cellY);
	cell left = maze.at(cellX - 1).at(cellY);
	cell down = maze.at(cellX).at(cellY + 1);

	if (!top.visited)
	{
		neightbours.push_back(top);
	}

	if (!right.visited)
	{
		neightbours.push_back(right);
	}

	if (!left.visited)
	{
		neightbours.push_back(left);
	}

	if (!down.visited)
	{
		neightbours.push_back(down);
	}

	if (neightbours.size() > 0)
	{
		int r = (rand() % neightbours.size());

		return neightbours.at(r);
	}

	return nullptr;
}


bool createLabirynt(int height, int width)
{
	return false;
}
