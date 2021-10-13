cmake_minimum_required(VERSION 3.20)
project(p2)

set(CMAKE_CXX_STANDARD 14)

include_directories(.)

add_executable(p2
        customer.cpp
        customer.h
        dateTest.cpp
        entree.cpp
        entree.h
        p2.cpp
        vendor.cpp
        vendor.h)
