let values=[];
let w=40;
let states=[];
function setup()
{
  createCanvas(windowWidth,windowHeight);
  values = new Array(floor(width/w));
  
  for(var i=0;i<values.length;i++)
  {
      values[i]=random(height);
      states[i]=-1;
  }
  bubbleSort(values);
}

async function bubbleSort(values)
{
    for(var i=values.length;i>=0;i--)
    {
        let j=values.length;
        while(j>=0)
        {
            if(values[j]>values[j+1])
            {
                states[j]=0;
                states[j+1]=1;
                await swap(values,j,j+1);
                states[j]=-1;
                states[j+1]=-1;
            }
            j--;
        } 
        if(!swap_check)
        {
            break;
        }
        
    }
}
function draw()
{
    background(255,0,0);

    for(var i=0;i<values.length;i++)
    {
        stroke(0);
        if(states[i]==0)
        {
            fill(0,255,0);
        }
        else if(states[i]==1)
        {
            fill(0,0,255);
        }
      else if(states[i]==2)
      {
        fill('orange');
      }
        else
        {
            fill(255);
        }
        rect(i * w, height - values[i], w, values[i]);
    }
}
async function swap(array,i,j)
{
    await sleep(50);
    var temp=array[i];
    array[i]=array[j];
    array[j]=temp;
    swap_check=true;
}

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }