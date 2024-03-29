#pragma once

#include <vector>
#include <random>
#include <thread>
#include <iostream>

#ifdef MAZECREATOR_EXPORTS
#define MAZECREATOR_API __declspec(dllexport)
#else
#define MAZECREATOR_API __declspec(dllimport)
#endif

class cell {

	bool leftWall, rightWall, topWall, bottomWall;
	bool isNUll, isVisited;
	int column, row;
	

public:
	cell();
	cell(int col_, int row_);

	void setVisited(bool newState);
	bool getVisited();
	int getColumn();
	int getRow();

	void setLeftWall(bool newValue);
	void setRighttWall(bool newValue);
	void setTopWall(bool newValue);
	void setBottomWall(bool newValue);

	bool getLeftWall();
	bool getRighttWall();
	bool getTopWall();
	bool getBottomWall();

};

class mazeCreator
{

	std::vector<cell> maze;
	std::vector<cell> route;
	int colls = 0, rows = 0, currentCellIndex;

public:
	mazeCreator(int labiryntWidth, int labiryntHeight, int cellSize);

	void labiryntCreator(int newHeight, int newWidth);

	void removeWall(int curentIdex, int nextIdex);

	cell checkNeightbours(int cellX, int cellY);

	cell getCellInRoute(int index);

	int index(int i, int j);

	int getRouteSize();

	

};

extern "C" MAZECREATOR_API bool createLabirynt(int coreNumber, int labiryntWidth, int labiryntHeight, int cellSize, int *ar, long* len);

