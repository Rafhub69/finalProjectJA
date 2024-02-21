
.code

Cell STRUCT 2 ; 
leftWall DWORD 1 ; 
rightWall DWORD 1 ; 
topWall DWORD 1 ; 
bottomWall DWORD 1 ;
Cell ENDS

MyProc1 proc
add RCX, RDX
mov RAX, RCX
ret
MyProc1 endp

end