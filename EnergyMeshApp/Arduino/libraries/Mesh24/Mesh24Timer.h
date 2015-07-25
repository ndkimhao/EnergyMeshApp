/*
This file is part of mesh24.
Copyright (C) 2014 Miklos Lengyel (j7only@gmail.com)

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program. If not, see <http://www.gnu.org/licenses/>.
*/

#ifndef _MESH24_TIMER_H
#define _MESH24_TIMER_H

class Mesh24Timer {
  public:
    Mesh24Timer(unsigned long interval = 0, boolean enable = true) {
      begin(interval);
	  this->enable = enable;
    }

    void inline __attribute__((always_inline)) begin(unsigned long interval) {
      last = millis();
      this->interval = interval;
    }
	
	void inline __attribute__((always_inline)) begin() {
      last = millis();
	  enable = true;
    }

    void inline __attribute__((always_inline)) stop() {
      enable = false;
    }

    bool inline __attribute__((always_inline)) isDue() {
      if (!enable || !interval) {
        return false;
      }
      unsigned long now = millis();
      bool result = false;
      if (interval < now - last) {
        result = true;
        last = now;
      }
      return result;
    }
	
	unsigned long inline __attribute__((always_inline)) getInterval() {
		return interval;
	}

  private:
    unsigned long last;
    unsigned long interval;
	boolean enable;
};

#endif
