#pragma once

#include <vector>
#include <random>

#ifdef MAZECREATOR_EXPORTS
#define MAZECREATOR_API __declspec(dllexport)
#else
#define MAZECREATOR_API __declspec(dllimport)
#endif

class cell {

	bool leftWall, rightWall, topWall, bottomWall;
	

public:
	cell();
	
	bool visited = false;

};

class labiryntCreator
{
	int currentCellx = 0, currentCelly = 0;
	std::vector<std::vector<cell> > maze;
	
	labiryntCreator(int newHeight, int newWidth);
	cell checkNeightbours(int cellX, int cellY);
};

//Funkcja która tworzy labirynt.
extern "C" MAZECREATOR_API bool createLabirynt(int height, int width);
