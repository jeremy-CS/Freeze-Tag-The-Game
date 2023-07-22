using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MapGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> nodes;
    public Graph Map;
    public List<Node> path = new List<Node>();

    // Start is called before the first frame update
    void Start()
    {
        GetMap();
    }

    //Drawing Map in the editor
    public void OnDrawGizmos()
    {
        if (Map == null)
            Start();

        foreach (Node node in Map.graphNodes)
        {
            //Drawing nodes
            Gizmos.color = Color.red;

            //Draw path
            if (path != null)
                if (path.Contains(node))
                    Gizmos.color = Color.green;

            Gizmos.DrawSphere(node.Position, 0.4f);

            //Drawing edges
            if (node.Neighbors != null)
            {
                Gizmos.color = Color.magenta;
                foreach (Node neighbors in node.Neighbors)
                {
                    Gizmos.DrawLine(node.Position, neighbors.Position);
                }
            }
        }
    }

    //Getting the Map information (Nodes/Vertices connections)
    public void GetMap()
    {
        GetNodes();
        GetVertices();
    }

    public void GetNodes()
    {
        //Getting every node for the graph
        Map = new Graph();
        foreach (GameObject nodePos in nodes)
        {
            Map.AddNode(nodePos.transform.position);
        }
    }

    public void GetVertices()
    {
        //Getting every connection of the graph (HARD CODED)
        //1
        Map.AddUndirectedEdge(Map.graphNodes[0], Map.graphNodes[1]);
        Map.AddUndirectedEdge(Map.graphNodes[0], Map.graphNodes[2]);
        Map.AddUndirectedEdge(Map.graphNodes[0], Map.graphNodes[3]);
        Map.AddUndirectedEdge(Map.graphNodes[0], Map.graphNodes[4]);
        //2
        Map.AddUndirectedEdge(Map.graphNodes[1], Map.graphNodes[2]);
        Map.AddUndirectedEdge(Map.graphNodes[1], Map.graphNodes[4]);
        Map.AddUndirectedEdge(Map.graphNodes[1], Map.graphNodes[5]);
        Map.AddUndirectedEdge(Map.graphNodes[1], Map.graphNodes[6]);
        //3
        Map.AddUndirectedEdge(Map.graphNodes[2], Map.graphNodes[3]);
        Map.AddUndirectedEdge(Map.graphNodes[2], Map.graphNodes[51]);
        Map.AddUndirectedEdge(Map.graphNodes[2], Map.graphNodes[53]);
        //4
        Map.AddUndirectedEdge(Map.graphNodes[3], Map.graphNodes[4]);
        Map.AddUndirectedEdge(Map.graphNodes[3], Map.graphNodes[87]);
        Map.AddUndirectedEdge(Map.graphNodes[3], Map.graphNodes[88]);
        //5
        Map.AddUndirectedEdge(Map.graphNodes[4], Map.graphNodes[94]);
        Map.AddUndirectedEdge(Map.graphNodes[4], Map.graphNodes[138]);
        Map.AddUndirectedEdge(Map.graphNodes[4], Map.graphNodes[139]);
        //6
        Map.AddUndirectedEdge(Map.graphNodes[5], Map.graphNodes[6]);
        Map.AddUndirectedEdge(Map.graphNodes[5], Map.graphNodes[7]);
        //7
        Map.AddUndirectedEdge(Map.graphNodes[6], Map.graphNodes[7]);
        Map.AddUndirectedEdge(Map.graphNodes[6], Map.graphNodes[137]);
        //8
        Map.AddUndirectedEdge(Map.graphNodes[7], Map.graphNodes[8]);
        Map.AddUndirectedEdge(Map.graphNodes[7], Map.graphNodes[9]);
        Map.AddUndirectedEdge(Map.graphNodes[7], Map.graphNodes[11]);
        Map.AddUndirectedEdge(Map.graphNodes[7], Map.graphNodes[12]);
        Map.AddUndirectedEdge(Map.graphNodes[7], Map.graphNodes[13]);
        Map.AddUndirectedEdge(Map.graphNodes[7], Map.graphNodes[14]);
        //9
        Map.AddUndirectedEdge(Map.graphNodes[8], Map.graphNodes[9]);
        Map.AddUndirectedEdge(Map.graphNodes[8], Map.graphNodes[10]);
        Map.AddUndirectedEdge(Map.graphNodes[8], Map.graphNodes[13]);
        Map.AddUndirectedEdge(Map.graphNodes[8], Map.graphNodes[14]);
        //10
        Map.AddUndirectedEdge(Map.graphNodes[9], Map.graphNodes[12]);
        Map.AddUndirectedEdge(Map.graphNodes[9], Map.graphNodes[13]);
        Map.AddUndirectedEdge(Map.graphNodes[9], Map.graphNodes[43]);
        Map.AddUndirectedEdge(Map.graphNodes[9], Map.graphNodes[44]);
        //11
        Map.AddUndirectedEdge(Map.graphNodes[10], Map.graphNodes[15]);
        Map.AddUndirectedEdge(Map.graphNodes[10], Map.graphNodes[16]);
        Map.AddUndirectedEdge(Map.graphNodes[10], Map.graphNodes[17]);
        //12
        Map.AddUndirectedEdge(Map.graphNodes[11], Map.graphNodes[14]);
        //13
        //14
        //15
        //16
        Map.AddUndirectedEdge(Map.graphNodes[15], Map.graphNodes[16]);
        Map.AddUndirectedEdge(Map.graphNodes[15], Map.graphNodes[17]);
        Map.AddUndirectedEdge(Map.graphNodes[15], Map.graphNodes[18]);
        Map.AddUndirectedEdge(Map.graphNodes[15], Map.graphNodes[19]);
        //17
        Map.AddUndirectedEdge(Map.graphNodes[16], Map.graphNodes[17]);
        //18
        //19
        Map.AddUndirectedEdge(Map.graphNodes[18], Map.graphNodes[19]);
        //20
        Map.AddUndirectedEdge(Map.graphNodes[19], Map.graphNodes[20]);
        //21
        Map.AddUndirectedEdge(Map.graphNodes[20], Map.graphNodes[21]);
        //22
        Map.AddUndirectedEdge(Map.graphNodes[21], Map.graphNodes[22]);
        Map.AddUndirectedEdge(Map.graphNodes[21], Map.graphNodes[23]);
        Map.AddUndirectedEdge(Map.graphNodes[21], Map.graphNodes[26]);
        Map.AddUndirectedEdge(Map.graphNodes[21], Map.graphNodes[27]);
        //23
        Map.AddUndirectedEdge(Map.graphNodes[22], Map.graphNodes[23]);
        Map.AddUndirectedEdge(Map.graphNodes[22], Map.graphNodes[26]);
        Map.AddUndirectedEdge(Map.graphNodes[22], Map.graphNodes[27]);
        //24
        Map.AddUndirectedEdge(Map.graphNodes[23], Map.graphNodes[24]);
        Map.AddUndirectedEdge(Map.graphNodes[23], Map.graphNodes[25]);
        //25
        Map.AddUndirectedEdge(Map.graphNodes[24], Map.graphNodes[25]);
        //26
        //27
        Map.AddUndirectedEdge(Map.graphNodes[26], Map.graphNodes[28]);
        Map.AddUndirectedEdge(Map.graphNodes[26], Map.graphNodes[30]);
        //28
        Map.AddUndirectedEdge(Map.graphNodes[27], Map.graphNodes[34]);
        Map.AddUndirectedEdge(Map.graphNodes[27], Map.graphNodes[38]);
        Map.AddUndirectedEdge(Map.graphNodes[27], Map.graphNodes[39]);
        //29
        Map.AddUndirectedEdge(Map.graphNodes[28], Map.graphNodes[29]);
        Map.AddUndirectedEdge(Map.graphNodes[28], Map.graphNodes[30]);
        //30
        //31
        Map.AddUndirectedEdge(Map.graphNodes[30], Map.graphNodes[31]);
        Map.AddUndirectedEdge(Map.graphNodes[30], Map.graphNodes[32]);
        //32
        Map.AddUndirectedEdge(Map.graphNodes[31], Map.graphNodes[32]);
        Map.AddUndirectedEdge(Map.graphNodes[31], Map.graphNodes[33]);
        Map.AddUndirectedEdge(Map.graphNodes[31], Map.graphNodes[34]);
        Map.AddUndirectedEdge(Map.graphNodes[31], Map.graphNodes[39]);
        //33
        //34
        //35
        Map.AddUndirectedEdge(Map.graphNodes[34], Map.graphNodes[35]);
        Map.AddUndirectedEdge(Map.graphNodes[34], Map.graphNodes[36]);
        Map.AddUndirectedEdge(Map.graphNodes[34], Map.graphNodes[37]);
        Map.AddUndirectedEdge(Map.graphNodes[34], Map.graphNodes[38]);
        //36
        Map.AddUndirectedEdge(Map.graphNodes[35], Map.graphNodes[36]);
        Map.AddUndirectedEdge(Map.graphNodes[35], Map.graphNodes[38]);
        Map.AddUndirectedEdge(Map.graphNodes[35], Map.graphNodes[40]);
        Map.AddUndirectedEdge(Map.graphNodes[35], Map.graphNodes[42]);
        //37
        Map.AddUndirectedEdge(Map.graphNodes[36], Map.graphNodes[37]);
        Map.AddUndirectedEdge(Map.graphNodes[36], Map.graphNodes[38]);
        //38
        //39
        Map.AddUndirectedEdge(Map.graphNodes[38], Map.graphNodes[39]);
        //40
        //41
        Map.AddUndirectedEdge(Map.graphNodes[40], Map.graphNodes[41]);
        Map.AddUndirectedEdge(Map.graphNodes[40], Map.graphNodes[42]);
        //42
        Map.AddUndirectedEdge(Map.graphNodes[41], Map.graphNodes[42]);
        //43
        Map.AddUndirectedEdge(Map.graphNodes[42], Map.graphNodes[43]);
        Map.AddUndirectedEdge(Map.graphNodes[42], Map.graphNodes[44]);
        //44
        Map.AddUndirectedEdge(Map.graphNodes[43], Map.graphNodes[44]);
        //45
        Map.AddUndirectedEdge(Map.graphNodes[44], Map.graphNodes[45]);
        Map.AddUndirectedEdge(Map.graphNodes[44], Map.graphNodes[46]);
        Map.AddUndirectedEdge(Map.graphNodes[44], Map.graphNodes[50]);
        //46
        Map.AddUndirectedEdge(Map.graphNodes[45], Map.graphNodes[46]);
        Map.AddUndirectedEdge(Map.graphNodes[45], Map.graphNodes[47]);
        Map.AddUndirectedEdge(Map.graphNodes[45], Map.graphNodes[50]);
        //47
        Map.AddUndirectedEdge(Map.graphNodes[46], Map.graphNodes[48]);
        Map.AddUndirectedEdge(Map.graphNodes[46], Map.graphNodes[50]);
        //48
        Map.AddUndirectedEdge(Map.graphNodes[47], Map.graphNodes[49]);
        //49
        Map.AddUndirectedEdge(Map.graphNodes[48], Map.graphNodes[49]);
        //50
        //51
        //52
        Map.AddUndirectedEdge(Map.graphNodes[51], Map.graphNodes[52]);
        Map.AddUndirectedEdge(Map.graphNodes[51], Map.graphNodes[53]);
        //53
        Map.AddUndirectedEdge(Map.graphNodes[52], Map.graphNodes[53]);
        Map.AddUndirectedEdge(Map.graphNodes[52], Map.graphNodes[54]);
        Map.AddUndirectedEdge(Map.graphNodes[52], Map.graphNodes[57]);
        Map.AddUndirectedEdge(Map.graphNodes[52], Map.graphNodes[58]);
        Map.AddUndirectedEdge(Map.graphNodes[52], Map.graphNodes[59]);
        //54
        Map.AddUndirectedEdge(Map.graphNodes[53], Map.graphNodes[69]);
        Map.AddUndirectedEdge(Map.graphNodes[53], Map.graphNodes[70]);
        //55
        Map.AddUndirectedEdge(Map.graphNodes[54], Map.graphNodes[55]);
        Map.AddUndirectedEdge(Map.graphNodes[54], Map.graphNodes[58]);
        //56
        Map.AddUndirectedEdge(Map.graphNodes[55], Map.graphNodes[56]);
        Map.AddUndirectedEdge(Map.graphNodes[55], Map.graphNodes[58]);
        //57
        Map.AddUndirectedEdge(Map.graphNodes[56], Map.graphNodes[57]);
        Map.AddUndirectedEdge(Map.graphNodes[56], Map.graphNodes[58]);
        Map.AddUndirectedEdge(Map.graphNodes[56], Map.graphNodes[59]);
        //58
        Map.AddUndirectedEdge(Map.graphNodes[57], Map.graphNodes[58]);
        Map.AddUndirectedEdge(Map.graphNodes[57], Map.graphNodes[59]);
        //59
        Map.AddUndirectedEdge(Map.graphNodes[58], Map.graphNodes[59]);
        //60
        Map.AddUndirectedEdge(Map.graphNodes[59], Map.graphNodes[60]);
        Map.AddUndirectedEdge(Map.graphNodes[59], Map.graphNodes[61]);
        Map.AddUndirectedEdge(Map.graphNodes[59], Map.graphNodes[62]);
        //61
        Map.AddUndirectedEdge(Map.graphNodes[60], Map.graphNodes[61]);
        Map.AddUndirectedEdge(Map.graphNodes[60], Map.graphNodes[62]);
        //62
        //63
        Map.AddUndirectedEdge(Map.graphNodes[62], Map.graphNodes[63]);
        Map.AddUndirectedEdge(Map.graphNodes[62], Map.graphNodes[64]);
        Map.AddUndirectedEdge(Map.graphNodes[62], Map.graphNodes[65]);
        //64
        Map.AddUndirectedEdge(Map.graphNodes[63], Map.graphNodes[64]);
        Map.AddUndirectedEdge(Map.graphNodes[63], Map.graphNodes[65]);
        Map.AddUndirectedEdge(Map.graphNodes[63], Map.graphNodes[66]);
        Map.AddUndirectedEdge(Map.graphNodes[63], Map.graphNodes[67]);
        Map.AddUndirectedEdge(Map.graphNodes[63], Map.graphNodes[68]);
        //65
        Map.AddUndirectedEdge(Map.graphNodes[64], Map.graphNodes[65]);
        //66
        //67
        Map.AddUndirectedEdge(Map.graphNodes[66], Map.graphNodes[67]);
        Map.AddUndirectedEdge(Map.graphNodes[66], Map.graphNodes[68]);
        Map.AddUndirectedEdge(Map.graphNodes[66], Map.graphNodes[69]);
        Map.AddUndirectedEdge(Map.graphNodes[66], Map.graphNodes[71]);
        //68
        Map.AddUndirectedEdge(Map.graphNodes[67], Map.graphNodes[68]);
        //69
        Map.AddUndirectedEdge(Map.graphNodes[68], Map.graphNodes[71]);
        Map.AddUndirectedEdge(Map.graphNodes[68], Map.graphNodes[72]);
        Map.AddUndirectedEdge(Map.graphNodes[68], Map.graphNodes[73]);
        //70
        Map.AddUndirectedEdge(Map.graphNodes[69], Map.graphNodes[70]);
        Map.AddUndirectedEdge(Map.graphNodes[69], Map.graphNodes[71]);
        //71
        //72
        Map.AddUndirectedEdge(Map.graphNodes[71], Map.graphNodes[72]);
        Map.AddUndirectedEdge(Map.graphNodes[71], Map.graphNodes[73]);
        //73
        Map.AddUndirectedEdge(Map.graphNodes[72], Map.graphNodes[73]);
        //74
        Map.AddUndirectedEdge(Map.graphNodes[73], Map.graphNodes[74]);
        Map.AddUndirectedEdge(Map.graphNodes[73], Map.graphNodes[76]);
        //75
        Map.AddUndirectedEdge(Map.graphNodes[74], Map.graphNodes[75]);
        Map.AddUndirectedEdge(Map.graphNodes[74], Map.graphNodes[76]);
        //76
        Map.AddUndirectedEdge(Map.graphNodes[75], Map.graphNodes[76]);
        //77
        Map.AddUndirectedEdge(Map.graphNodes[76], Map.graphNodes[77]);
        Map.AddUndirectedEdge(Map.graphNodes[76], Map.graphNodes[80]);
        Map.AddUndirectedEdge(Map.graphNodes[76], Map.graphNodes[82]);
        //78
        Map.AddUndirectedEdge(Map.graphNodes[77], Map.graphNodes[78]);
        Map.AddUndirectedEdge(Map.graphNodes[77], Map.graphNodes[79]);
        Map.AddUndirectedEdge(Map.graphNodes[77], Map.graphNodes[80]);
        Map.AddUndirectedEdge(Map.graphNodes[77], Map.graphNodes[81]);
        Map.AddUndirectedEdge(Map.graphNodes[77], Map.graphNodes[82]);
        //79
        Map.AddUndirectedEdge(Map.graphNodes[78], Map.graphNodes[79]);
        Map.AddUndirectedEdge(Map.graphNodes[78], Map.graphNodes[81]);
        Map.AddUndirectedEdge(Map.graphNodes[78], Map.graphNodes[83]);
        Map.AddUndirectedEdge(Map.graphNodes[78], Map.graphNodes[86]);
        //80
        Map.AddUndirectedEdge(Map.graphNodes[79], Map.graphNodes[81]);
        //81
        Map.AddUndirectedEdge(Map.graphNodes[80], Map.graphNodes[82]);
        //82
        //83
        //84
        Map.AddUndirectedEdge(Map.graphNodes[83], Map.graphNodes[84]);
        Map.AddUndirectedEdge(Map.graphNodes[83], Map.graphNodes[85]);
        Map.AddUndirectedEdge(Map.graphNodes[83], Map.graphNodes[86]);
        //85
        Map.AddUndirectedEdge(Map.graphNodes[84], Map.graphNodes[85]);
        Map.AddUndirectedEdge(Map.graphNodes[84], Map.graphNodes[86]);
        //86
        Map.AddUndirectedEdge(Map.graphNodes[85], Map.graphNodes[86]);
        //87
        Map.AddUndirectedEdge(Map.graphNodes[86], Map.graphNodes[87]);
        Map.AddUndirectedEdge(Map.graphNodes[86], Map.graphNodes[88]);
        //88
        Map.AddUndirectedEdge(Map.graphNodes[87], Map.graphNodes[88]);
        //89
        Map.AddUndirectedEdge(Map.graphNodes[88], Map.graphNodes[89]);
        Map.AddUndirectedEdge(Map.graphNodes[88], Map.graphNodes[90]);
        Map.AddUndirectedEdge(Map.graphNodes[88], Map.graphNodes[92]);
        //90
        Map.AddUndirectedEdge(Map.graphNodes[89], Map.graphNodes[90]);
        Map.AddUndirectedEdge(Map.graphNodes[89], Map.graphNodes[92]);
        Map.AddUndirectedEdge(Map.graphNodes[89], Map.graphNodes[95]);
        //91
        Map.AddUndirectedEdge(Map.graphNodes[90], Map.graphNodes[91]);
        //92
        //93
        Map.AddUndirectedEdge(Map.graphNodes[92], Map.graphNodes[93]);
        Map.AddUndirectedEdge(Map.graphNodes[92], Map.graphNodes[94]);
        //94
        Map.AddUndirectedEdge(Map.graphNodes[93], Map.graphNodes[94]);
        //95
        Map.AddUndirectedEdge(Map.graphNodes[94], Map.graphNodes[129]);
        Map.AddUndirectedEdge(Map.graphNodes[94], Map.graphNodes[138]);
        //96
        Map.AddUndirectedEdge(Map.graphNodes[95], Map.graphNodes[97]);
        Map.AddUndirectedEdge(Map.graphNodes[95], Map.graphNodes[99]);
        //97
        Map.AddUndirectedEdge(Map.graphNodes[96], Map.graphNodes[97]);
        Map.AddUndirectedEdge(Map.graphNodes[96], Map.graphNodes[98]);
        Map.AddUndirectedEdge(Map.graphNodes[96], Map.graphNodes[109]);
        Map.AddUndirectedEdge(Map.graphNodes[96], Map.graphNodes[110]);
        Map.AddUndirectedEdge(Map.graphNodes[96], Map.graphNodes[111]);
        //98
        Map.AddUndirectedEdge(Map.graphNodes[97], Map.graphNodes[100]);
        //99
        //100
        //101
        Map.AddUndirectedEdge(Map.graphNodes[100], Map.graphNodes[101]);
        //102
        Map.AddUndirectedEdge(Map.graphNodes[101], Map.graphNodes[102]);
        //103
        Map.AddUndirectedEdge(Map.graphNodes[102], Map.graphNodes[103]);
        Map.AddUndirectedEdge(Map.graphNodes[102], Map.graphNodes[104]);
        Map.AddUndirectedEdge(Map.graphNodes[102], Map.graphNodes[105]);
        Map.AddUndirectedEdge(Map.graphNodes[102], Map.graphNodes[106]);
        Map.AddUndirectedEdge(Map.graphNodes[102], Map.graphNodes[107]);
        //104
        Map.AddUndirectedEdge(Map.graphNodes[103], Map.graphNodes[104]);
        Map.AddUndirectedEdge(Map.graphNodes[103], Map.graphNodes[105]);
        //105
        Map.AddUndirectedEdge(Map.graphNodes[104], Map.graphNodes[106]);
        Map.AddUndirectedEdge(Map.graphNodes[104], Map.graphNodes[107]);
        //106
        //107
        Map.AddUndirectedEdge(Map.graphNodes[106], Map.graphNodes[107]);
        //108
        Map.AddUndirectedEdge(Map.graphNodes[107], Map.graphNodes[108]);
        Map.AddUndirectedEdge(Map.graphNodes[107], Map.graphNodes[109]);
        //109
        Map.AddUndirectedEdge(Map.graphNodes[108], Map.graphNodes[109]);
        //110
        Map.AddUndirectedEdge(Map.graphNodes[109], Map.graphNodes[110]);
        //111
        Map.AddUndirectedEdge(Map.graphNodes[110], Map.graphNodes[111]);
        //112
        Map.AddUndirectedEdge(Map.graphNodes[111], Map.graphNodes[112]);
        Map.AddUndirectedEdge(Map.graphNodes[111], Map.graphNodes[114]);
        Map.AddUndirectedEdge(Map.graphNodes[111], Map.graphNodes[115]);
        //113
        Map.AddUndirectedEdge(Map.graphNodes[112], Map.graphNodes[113]);
        Map.AddUndirectedEdge(Map.graphNodes[112], Map.graphNodes[114]);
        Map.AddUndirectedEdge(Map.graphNodes[112], Map.graphNodes[115]);
        Map.AddUndirectedEdge(Map.graphNodes[112], Map.graphNodes[116]);
        Map.AddUndirectedEdge(Map.graphNodes[112], Map.graphNodes[119]);
        //114
        Map.AddUndirectedEdge(Map.graphNodes[113], Map.graphNodes[116]);
        Map.AddUndirectedEdge(Map.graphNodes[113], Map.graphNodes[118]);
        Map.AddUndirectedEdge(Map.graphNodes[113], Map.graphNodes[119]);
        Map.AddUndirectedEdge(Map.graphNodes[113], Map.graphNodes[120]);
        Map.AddUndirectedEdge(Map.graphNodes[113], Map.graphNodes[122]);
        //115
        Map.AddUndirectedEdge(Map.graphNodes[114], Map.graphNodes[115]);
        //116
        //117
        Map.AddUndirectedEdge(Map.graphNodes[116], Map.graphNodes[119]);
        //118
        Map.AddUndirectedEdge(Map.graphNodes[117], Map.graphNodes[118]);
        //119
        Map.AddUndirectedEdge(Map.graphNodes[118], Map.graphNodes[122]);
        //120
        //121
        Map.AddUndirectedEdge(Map.graphNodes[120], Map.graphNodes[121]);
        Map.AddUndirectedEdge(Map.graphNodes[120], Map.graphNodes[122]);
        Map.AddUndirectedEdge(Map.graphNodes[120], Map.graphNodes[123]);
        //122
        Map.AddUndirectedEdge(Map.graphNodes[121], Map.graphNodes[123]);
        //123
        //124
        Map.AddUndirectedEdge(Map.graphNodes[123], Map.graphNodes[124]);
        Map.AddUndirectedEdge(Map.graphNodes[123], Map.graphNodes[125]);
        Map.AddUndirectedEdge(Map.graphNodes[123], Map.graphNodes[126]);
        Map.AddUndirectedEdge(Map.graphNodes[123], Map.graphNodes[131]);
        //125
        Map.AddUndirectedEdge(Map.graphNodes[124], Map.graphNodes[125]);
        //126
        Map.AddUndirectedEdge(Map.graphNodes[125], Map.graphNodes[126]);
        Map.AddUndirectedEdge(Map.graphNodes[125], Map.graphNodes[127]);
        //127
        Map.AddUndirectedEdge(Map.graphNodes[126], Map.graphNodes[127]);
        Map.AddUndirectedEdge(Map.graphNodes[126], Map.graphNodes[131]);
        //128
        Map.AddUndirectedEdge(Map.graphNodes[127], Map.graphNodes[128]);
        Map.AddUndirectedEdge(Map.graphNodes[127], Map.graphNodes[129]);
        //129
        Map.AddUndirectedEdge(Map.graphNodes[128], Map.graphNodes[129]);
        Map.AddUndirectedEdge(Map.graphNodes[128], Map.graphNodes[130]);
        //130
        Map.AddUndirectedEdge(Map.graphNodes[129], Map.graphNodes[130]);
        Map.AddUndirectedEdge(Map.graphNodes[129], Map.graphNodes[138]);
        Map.AddUndirectedEdge(Map.graphNodes[129], Map.graphNodes[139]);
        //131
        Map.AddUndirectedEdge(Map.graphNodes[130], Map.graphNodes[132]);
        Map.AddUndirectedEdge(Map.graphNodes[130], Map.graphNodes[133]);
        //132
        Map.AddUndirectedEdge(Map.graphNodes[131], Map.graphNodes[132]);
        Map.AddUndirectedEdge(Map.graphNodes[131], Map.graphNodes[133]);
        //133
        Map.AddUndirectedEdge(Map.graphNodes[132], Map.graphNodes[133]);
        //134
        Map.AddUndirectedEdge(Map.graphNodes[133], Map.graphNodes[134]);
        Map.AddUndirectedEdge(Map.graphNodes[133], Map.graphNodes[135]);
        //135
        Map.AddUndirectedEdge(Map.graphNodes[134], Map.graphNodes[135]);
        Map.AddUndirectedEdge(Map.graphNodes[134], Map.graphNodes[136]);
        //136
        Map.AddUndirectedEdge(Map.graphNodes[135], Map.graphNodes[136]);
        Map.AddUndirectedEdge(Map.graphNodes[135], Map.graphNodes[137]);
        //137
        //138
        //139
        Map.AddUndirectedEdge(Map.graphNodes[138], Map.graphNodes[139]);
        //140
    }
}
