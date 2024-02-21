#include "pch.h"
#include "mazeCreator.h"

cell::cell()
{
	topWall = true;
	rightWall = true;
	bottomWall = true;
	leftWall = true;

	isVisited = false;
}

cell::cell(int col_, int row_)
{
	column = col_;
	row = row_;

	topWall = true;
	rightWall = true;
	bottomWall = true;
	leftWall = true;

	isVisited = false;
}

int cell::getColumn()
{
	return column;
}

int cell::getRow()
{
	return row;
}

void cell::setVisited(bool newState)
{
	isVisited = newState;
}

bool cell::getVisited()
{
	return isVisited;
}

void  cell::setLeftWall(bool newValue)
{
	this->leftWall = newValue;
}

void  cell::setRighttWall(bool newValue) {

	this->rightWall = newValue;
}

void  cell::setTopWall(bool newValue)
{
	this->topWall = newValue;
}

void  cell::setBottomWall(bool newValue)
{
	this->bottomWall = newValue;
}

bool cell::getLeftWall()
{
	return this->leftWall;
}

bool cell::getRighttWall()
{
	return this->rightWall;
}

bool cell::getTopWall()
{
	return this->topWall;
}

bool cell::getBottomWall()
{
	return this->bottomWall;
}


void mazeCreator::removeWall(int indexA, int indexB)
{
	int x = maze.at(indexA).getColumn() - maze.at(indexB).getColumn();
	int y  = maze.at(indexA).getRow() - maze.at(indexB).getRow();

	if (x == 1)
	{
		maze.at(indexA).setLeftWall(false);
		maze.at(indexB).setRighttWall(false);
	}
	else if (x == -1)
	{
		maze.at(indexB).setLeftWall(false);
		maze.at(indexA).setRighttWall(false);
	}

	if (y == 1)
	{
		maze.at(indexA).setTopWall(false);
		maze.at(indexB).setBottomWall(false);
	}
	else if (y == -1)
	{
		maze.at(indexB).setTopWall(false);
		maze.at(indexA).setBottomWall(false);
	}



}

mazeCreator::mazeCreator(int labiryntWidth, int labiryntHeight, int cellSize)
{
	 colls = static_cast<int>(labiryntWidth / cellSize);
	 rows = static_cast<int>(labiryntHeight / cellSize);

	 currentCellIndex = 0;

	 maze.at(currentCellIndex).setVisited(true);

	 while (maze.size() != route.size())
	 {
		 cell next = checkNeightbours(maze.at(currentCellIndex).getColumn(), maze.at(currentCellIndex).getRow());

		 if (next.getColumn() != maze.at(currentCellIndex).getColumn() && next.getRow() != maze.at(currentCellIndex).getRow())
		 {
			 next.setVisited(true);

			 route.push_back(next);

			 removeWall(currentCellIndex, index(next.getColumn(), next.getRow()));

			 currentCellIndex = index(next.getColumn(), next.getRow());
		 }
		 else if (route.size() > 0)
		 {
			 cell n = route.at(route.size() - 1);
			 route.pop_back();
			 currentCellIndex = index(n.getColumn(), n.getRow());
		 }
	 }
	 
}



int mazeCreator::index(int i, int j)
{
	if (i < 0 || j < 0  || i > colls - 1 || j > rows - 1)
	{
		return -1;
	}

	return i + j * colls;
}

void mazeCreator::labiryntCreator(int newHeight, int newWidth)
{
	for (int i = 0; i < newHeight; i++)
	{
		for (int j = 0; j < newHeight; j++)
		{
			cell c(j, i);
			maze.push_back(c);
		}
	}

}

cell mazeCreator::getCellInRoute(int index)
{
	return route.at(index);
}

int mazeCreator::getRouteSize()
{
	return route.size();
}

cell mazeCreator::checkNeightbours(int cellX, int cellY)
{
	srand((unsigned)time(NULL));

	std::vector< cell> neightbours;

	cell top = maze.at(index(cellX, cellY - 1));
	cell right = maze.at(index(cellX + 1, cellY));
	cell left = maze.at(index(cellX - 1, cellY));
	cell bottom = maze.at(index(cellX, cellY + 1));

	if (index(cellX, cellY - 1) != -1 && !top.getVisited())
	{
		neightbours.push_back(top);
	}

	if (index(cellX + 1, cellY) != -1 && !right.getVisited())
	{
		neightbours.push_back(right);
	}

	if (index(cellX, cellY + 1) != -1 && !bottom.getVisited())
	{
		neightbours.push_back(bottom);
	}

	if (index(cellX - 1, cellY) != -1 && !left.getVisited())
	{
		neightbours.push_back(left);
	}

	

	if (neightbours.size() > 0)
	{
		int r = (rand() % neightbours.size());

		return neightbours.at(r);
	}
	else
	{
		return maze.at(index(cellX, cellY));
	}


}


bool createLabirynt(int coreNumber, int labiryntWidth, int labiryntHeight, int cellSize, int* ar, long* len)
{
	mazeCreator newMaze(labiryntWidth, labiryntHeight, cellSize);

	cell newCell;

	int n = 0;

	*len = 3330;
	auto size = (*len) * sizeof(int);


	for (int i = 0; i < newMaze.getRouteSize(); i++)
	{
		newCell = newMaze.getCellInRoute(i);

		ar[n] = newCell.getColumn();
		ar[n + 1] = newCell.getRow();
		ar[n + 2] = int(newCell.getLeftWall());
		ar[n + 3] = int(newCell.getBottomWall());
		ar[n + 4] = int(newCell.getRighttWall());
		ar[n + 5] = int(newCell.getTopWall());

		n += 6;
	}
	
	return true;
}
