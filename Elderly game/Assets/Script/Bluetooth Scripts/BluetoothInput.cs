using System.Collections;
using System.Collections.Generic;

public class BluetoothInput
{
    public int controllerId;
    public int input;

    public BluetoothInput(int controllerId, int input) {
        this.controllerId = controllerId;
        this.input = input;
    }
}
